using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class KeyDemo : NetworkBehaviour
    { Rigidbody   _rigidbody;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var direction = (transform.position - other.gameObject.transform.position);
                _rigidbody.AddForce(new Vector3(direction.x,direction.y,0).normalized * impactForce, ForceMode.Impulse);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var direction = (transform.position - other.gameObject.transform.position);
                _rigidbody.AddForce(new Vector3(direction.x,direction.y,0).normalized * impactForce/3.0f, ForceMode.Impulse);
            }
        }
        
        
    }
}
