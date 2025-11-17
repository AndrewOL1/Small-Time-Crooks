using PurrNet;
using UnityEngine;

namespace AO.SyncVarTesting
{
    public class ServerVar : NetworkBehaviour
    {
        //Creates a new instance of the dictionary - `true` means it is owner auth. 
        [SerializeField] private SyncDictionary<GameObject, bool> myDictionary = new(true);

        protected override void OnSpawned()
        {
            //Subscribing to changes made to the dictionary
            myDictionary.onChanged += OnDictionaryChanged;
        }
        [ObserversRpc]
        private void OnDictionaryChanged(SyncDictionaryChange<GameObject, bool> change)
        {
            //This is called for everyone when the dictionary changes.
            //It will log out the Key, Value and operation
            Debug.Log($"Dictionary updated: {change}");
            Callout();
        }
        
        private void Callout()
        {
            foreach (var obj in myDictionary)
            {
                obj.Key.GetComponent<SyncVarTestingScript>().DebugTest();
            }
        }

        public void ChangeMyDictionary(GameObject player,bool vr)
        {
            myDictionary[player] = vr;
            //This will change or add a value to the dictionary
            //myDictionary[123] = 0.69f;
    
            //This will remove the value from the dictionary
            //myDictionary.Remove(123);
    
            //This will clear the dictionary
            //myDictionary.Clear();
    
            //This will mark the key as dirty
            //myDictionary.SetDirty(123);
        }
    }
}
