using System;
using UnityEngine;
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
        [SerializeField] 
        private bool _isVR=false;

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
               _isVR=true;
            }
  
            SceneManager.LoadScene(_isVR ? sceneToLoadVR : sceneToLoad);
        }
    }
}
