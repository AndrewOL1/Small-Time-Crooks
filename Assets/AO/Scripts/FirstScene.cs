using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.XR.Management;

namespace AO.Scripts
{
    public class FirstScene : MonoBehaviour
    {
        PlayerInput _playerInput;
        [SerializeField]
        private string sceneToLoad,sceneToLoadVR;

        public UnityEvent vrIsOn;
        public UnityEvent vrIsOff;
        
        public bool vr=false;

        [SerializeField] private float timer;
        private void Awake()
        {
            _playerInput=gameObject.GetComponent<PlayerInput>();
        }

        private void Start()
        {
            Invoke("SetScene",timer);
        }

        private void SetScene()
        {
            if (XRGeneralSettings.Instance.Manager.activeLoader != null) {
               vrIsOn.Invoke();
               vr = true;
            }
            else
            {
                vrIsOn.Invoke();
            }
        }
    }
}
