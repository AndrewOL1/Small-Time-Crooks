using System;
using PurrLobby;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AO.Scripts
{
    public class EventManager : MonoBehaviour
    {
        [SerializeField] private GameObject eventSystem, eventSystemVR;
        [SerializeField] private bool debug;
        private void Awake()
        {
            if (FindFirstObjectByType<PcVRDebugInit>()!=null)
            {
                if(FindFirstObjectByType<PcVRDebugInit>().VrPlayer)
                    eventSystemVR.SetActive(true);
                else
                    eventSystem.SetActive(true);
            }
            else
            {
                if (FindFirstObjectByType<LobbyDataHolder>().isVRPlayer)
                    eventSystemVR.SetActive(true);
                else
                {
                    eventSystem.SetActive(true);
                }
            }
        }
    }
}
