using System;
using PurrLobby;
using UnityEngine;
using PurrNet;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Serialization;

namespace AO.Scripts
{
    public class TogglePlayer : NetworkBehaviour
    {
        [SerializeField] private GameObject pcPlayer, vrPlayer;
        [SerializeField] private bool debug;
        private ServerPlayerType _playerType;
        private void Awake()
        {
    
        }
        protected override void OnSpawned()
        {
            if(!isOwner)return;
            if (FindFirstObjectByType<LobbyDataHolder>() != null)
            {
                if (FindFirstObjectByType<LobbyDataHolder>().isVRPlayer)
                {
                    vrPlayer.SetActive(true);
                    Startup();
                    CallPlayerType(true);
    
                }
                else
                {
                    pcPlayer.SetActive(true);
                    CallPlayerType(false);
                }
            }
            else if(FindFirstObjectByType<PcVRDebugInit>()!=null)//old code
            {
                if (FindFirstObjectByType<PcVRDebugInit>().VrPlayer)
                {
                    vrPlayer.SetActive(true);
                    Startup();
                }
                else
                    pcPlayer.SetActive(true);
            }
        }
        public void Start()
        {
            /*
            else
            {
                if (!identity.isOwner) return;
                if (FindFirstObjectByType<LobbyDataHolder>().isVRPlayer)
                    vrPlayer.SetActive(true);
                else
                {
                    pcPlayer.SetActive(true);
                }
            }
            */
        }
        [ServerRpc(requireOwnership: false)]
        private void CallPlayerType(bool value)
        {
            if (FindFirstObjectByType<ServerPlayerType>() == null) return;
            _playerType = FindFirstObjectByType<ServerPlayerType>();
            _playerType.AddPlayerType(this, value);
        }
        public void Join(bool vr)
        {
            if (vr)
            {
                vrPlayer.SetActive(true);
            }
            else
            {
                pcPlayer.SetActive(true);
            }
        }

        private void Startup()
        {
            vrPlayer.GetComponentInChildren<InputActionManager>().enabled = true;
            vrPlayer.GetComponentInChildren<Camera>().enabled = true;
            vrPlayer.GetComponentInChildren<AudioListener>().enabled = true;
        }
    }
}

