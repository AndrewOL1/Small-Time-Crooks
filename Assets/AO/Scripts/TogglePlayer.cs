using System;
using PurrLobby;
using UnityEngine;
using PurrNet;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace AO.Scripts
{
    public class TogglePlayer : NetworkBehaviour
    {
        [SerializeField] private GameObject pcPlayer, vrPlayer;
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
                if (FindFirstObjectByType<PcVRDebugInit>().VrPlayer)
                {
                    vrPlayer.SetActive(true);
                    Startup();
                }
                else
                    pcPlayer.SetActive(true);
            }
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
        }

        private void Startup()
        {
            vrPlayer.GetComponentInChildren<InputActionManager>().enabled = true;
            vrPlayer.GetComponentInChildren<Camera>().enabled = true;
            vrPlayer.GetComponentInChildren<AudioListener>().enabled = true;
        }
    }
}

