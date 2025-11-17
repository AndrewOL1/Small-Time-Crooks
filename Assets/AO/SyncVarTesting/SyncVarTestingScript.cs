using PurrNet;
using UnityEngine;

namespace AO.SyncVarTesting
{
    public class SyncVarTestingScript : NetworkBehaviour
    {
        [SerializeField] private ServerVar serverVar;

        public bool temp;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void OnSpawned()
        {
            if(!isOwner)return;
            serverVar=FindFirstObjectByType<ServerVar>();
            Joins(temp);
        }

        [ServerRpc(requireOwnership: false)]
        private void Joins(bool _temp)
        {
            serverVar=FindFirstObjectByType<ServerVar>();
            serverVar.ChangeMyDictionary(this.gameObject, _temp);
        }

        public void DebugTest()
        {
            Debug.Log(gameObject.name+ " : "+ temp.ToString());
        }
    }
}
