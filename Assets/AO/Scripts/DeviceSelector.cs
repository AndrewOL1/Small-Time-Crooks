using System;
using PurrLobby;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace AO.Scripts
{
    public class DeviceSelector : MonoBehaviour
    {
        LobbyDataHolder _lobbyData;
        TMP_Dropdown _dropdown;
        [SerializeField]
        FirstScene firstScene;

        private void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _lobbyData = FindAnyObjectByType<LobbyDataHolder>();
        }

        public void UpdatePlayerDevice(int deviceId)
        {
            _lobbyData.isVRPlayer = deviceId==1;
        }
        public void UpdatePlayerDevice()
        {
            _lobbyData.isVRPlayer = _dropdown.value==1;
        }

        public void VrPlayerDevice()
        {
            _lobbyData.isVRPlayer = true;
        }
    }
}
