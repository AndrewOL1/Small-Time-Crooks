using System;
using PurrLobby;
using UnityEngine;

namespace AO.Scripts
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject eventSystem,eventSystemVR;
        private void Awake()
        {
            if(FindFirstObjectByType<LobbyDataHolder>().isVRPlayer)
                eventSystemVR.SetActive(true);
            else
            {
                eventSystem.SetActive(true);
            }
        }
    }
}
