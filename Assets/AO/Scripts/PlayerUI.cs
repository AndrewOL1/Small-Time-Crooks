using System;
using PurrLobby;
using PurrNet;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace AO.Scripts
{
    public class PlayerUI : MonoBehaviour
    {
        private LobbyDataHolder _lobbyDataHolder;
        private Canvas _playerUI;
        [SerializeField]
        private PlayerInput playerInput;

        private void Start()
        {
            _lobbyDataHolder = FindFirstObjectByType<LobbyDataHolder>();
            _playerUI = GetComponent<Canvas>();
        }

        public void OpenUI()
        {
            _playerUI.enabled = true;
            playerInput.SwitchCurrentActionMap("UI");
            
        }
        public void CloseUI()
        {
            _playerUI.enabled = false;
            playerInput.SwitchCurrentActionMap("Player");
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void LeaveGame()
        {
            if (_lobbyDataHolder.CurrentLobby.IsOwner)
            {
                NetworkManager.main.StopServer();
                //return to offline scene
            }
            else
            {
                NetworkManager.main.StopClient();
            }

            SceneManager.LoadScene(_lobbyDataHolder.isVRPlayer ? "OfflineSceneTestVR" : "OfflineSceneTest");
        }
        public void CloseGame()
        {
            if (_lobbyDataHolder.CurrentLobby.IsOwner)
            {
                NetworkManager.main.StopServer();
            }
            else
            {
                NetworkManager.main.StopClient();
            }

            Application.Quit();
        }
    }
}
