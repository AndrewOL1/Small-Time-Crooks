using System.Collections;
using PurrNet;
using PurrNet.Logging;
using PurrNet.Steam;
using PurrNet.Transports;
using Steamworks;
using UnityEngine;

#if UTP_LOBBYRELAY
using PurrNet.UTP;
using Unity.Services.Relay.Models;
#endif

namespace PurrLobby
{
    public class ConnectionStarter : MonoBehaviour
    {
        private NetworkManager _networkManager;
        private LobbyDataHolder _lobbyDataHolder;
        private SteamTransport _steamTransport;
        private UDPTransport _udpTransport;

        private bool _isFromLobby;
        
        private void Awake()
        {
            if (!TryGetComponent(out _steamTransport))
            {
                PurrLogger.LogError($"Failed to get {nameof(SteamTransport)} component.",this);
            }
            if (!TryGetComponent(out _udpTransport))
            {
                PurrLogger.LogError($"Failed to get {nameof(UDPTransport)} component.",this);
            }
            if(!TryGetComponent(out _networkManager)) {
                PurrLogger.LogError($"Failed to get {nameof(NetworkManager)} component.", this);
            }
            
            _lobbyDataHolder = FindFirstObjectByType<LobbyDataHolder>();
            
            if(!_lobbyDataHolder)
                PurrLogger.LogError($"Failed to get {nameof(LobbyDataHolder)} component.", this);
            else
                _isFromLobby = true;
        }

        private void Start()
        {
            if (!_networkManager)
            {
                PurrLogger.LogError($"Failed to start connection. {nameof(NetworkManager)} is null!", this);
                return;
            }

            if (!_steamTransport)
            {
                PurrLogger.LogError($"Failed to start connection. {nameof(SteamTransport)} is null!", this);
                return;
            }

            if(_networkManager.transport is PurrTransport) {
                (_networkManager.transport as PurrTransport).roomName = _lobbyDataHolder.CurrentLobby.LobbyId;
            }

            if (_isFromLobby)
            {
                StartFromLobby();
            }
            
#if UTP_LOBBYRELAY
            else if(_networkManager.transport is UTPTransport) {
                if(_lobbyDataHolder.CurrentLobby.IsOwner) {
                    (_networkManager.transport as UTPTransport).InitializeRelayServer((Allocation)_lobbyDataHolder.CurrentLobby.ServerObject);
                }
                (_networkManager.transport as UTPTransport).InitializeRelayClient(_lobbyDataHolder.CurrentLobby.Properties["JoinCode"]);
            }
#else
                //P2P Connection, receive IP/Port from server
#endif

            if(_lobbyDataHolder.CurrentLobby.IsOwner)
                _networkManager.StartServer();
            StartCoroutine(StartClient());
        }

        private void StartFromLobby()
        {
            _networkManager.transport = _steamTransport;
            if (!_lobbyDataHolder)
            {
                PurrLogger.LogError($"Failed to start connection. {nameof(LobbyDataHolder)} is null!", this);
                return;
            }
            if (!_lobbyDataHolder.CurrentLobby.IsValid)
            {
                PurrLogger.LogError($"Failed to start connection. Lobby is invalid!", this);
                return;
            }

            if (!ulong.TryParse(_lobbyDataHolder.CurrentLobby.LobbyId, out ulong ulobbyId))
            {
                Debug.LogError($"Failed to parse lobbyid into ulong", this);
                return;
            }
            
            var lobbyOwner = SteamMatchmaking.GetLobbyOwner(new CSteamID(ulobbyId));
            if (!lobbyOwner.IsValid())
            {
                Debug.LogError($"Failed to get looby owner from parsed lobby ID", this);
                return;
            }

            _steamTransport.address = lobbyOwner.ToString();
        }

        private IEnumerator StartClient()
        {
            yield return new WaitForSeconds(1f);
            _networkManager.StartClient();
        }
    }
}
