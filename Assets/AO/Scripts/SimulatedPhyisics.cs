using System;
using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class SimulatedPhyisics : NetworkBehaviour
    {
        Rigidbody   _rigidbody;
        [SerializeField] private float impactForce;
        [SerializeField] private float gravity;
        private void Start()
        {
        }

        protected override void OnSpawned(bool asServer)
        {
            base.OnSpawned(asServer);
            _rigidbody=GetComponent<Rigidbody>();
            networkManager.onTick += OnTick;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            networkManager.onTick -= OnTick;
        }

        private void OnTick(bool asServer)
        {
            Move();
        }

        [ServerRpc]
        private void Move()
        {
            _rigidbody.AddForce(Vector3.down * gravity,ForceMode.Acceleration);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("GrabObject"))
            {
                var direction = (transform.position - other.gameObject.transform.position).normalized;
                _rigidbody.AddForce(direction * impactForce, ForceMode.Impulse);
            }
        }
        
        
    }
}
