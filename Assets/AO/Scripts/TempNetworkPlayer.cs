using PurrNet;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections;

namespace AO.Scripts
{
    public class TempNetworkPlayer : NetworkIdentity
    {
        PlayerInput _playerInput;
        private Vector2 _movement;
        [SerializeField]
        float speed;

        protected override void OnSpawned()
        {
            base.OnSpawned();
            enabled = isOwner;
            enabled = isOwner;
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.enabled = isOwner;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void UpdateMovement(InputAction.CallbackContext content)
        {
            _movement = content.ReadValue<Vector2>();
        }

        private void Move()
        {
            transform.Translate((_movement.x*speed), 0, (_movement.y*speed));
        }
    }
}
