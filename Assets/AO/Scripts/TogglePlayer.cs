using System;
using PurrLobby;
using UnityEngine;
using PurrNet;
using UnityEngine.EventSystems;
namespace AO.Scripts
{
    public class TogglePlayer : NetworkBehaviour
    {
        [SerializeField] private GameObject eventSystem, eventSystemVR;
        [SerializeField] private bool debug;
        private void Awake()
        {

        }

        public void Start()
        {
            NetworkIdentity identity = GetComponent<NetworkIdentity>();
            if (FindFirstObjectByType<PcVRDebugInit>()!=null)
            {
                if (!identity.isOwner) return;
                if(FindFirstObjectByType<PcVRDebugInit>().VrPlayer)
                    eventSystemVR.SetActive(true);
                else
                    eventSystem.SetActive(true);
            }
            else
            {
                if (!identity.isOwner) return;
                if (FindFirstObjectByType<LobbyDataHolder>().isVRPlayer)
                    eventSystemVR.SetActive(true);
                else
                {
                    eventSystem.SetActive(true);
                }
            }
        }

        async void Startup()
        {
            try
            {
               // await
            }
            catch (Exception e)
            {
                throw; // TODO handle exception
            }
        }
    }
}

