using System;
using PurrLobby;
using UnityEngine;

namespace AO.Scripts
{
    public class CloseLobbyInEditor : MonoBehaviour
    {
        private LobbyManager _lobbyManager;

        private void Start()
        {
            _lobbyManager = GetComponent<LobbyManager>();
        }

        private void OnApplicationQuit()
        {
            if (_lobbyManager.CurrentLobby.IsValid)
            {
                _lobbyManager.LeaveLobby();
            }
        }
    }
}
