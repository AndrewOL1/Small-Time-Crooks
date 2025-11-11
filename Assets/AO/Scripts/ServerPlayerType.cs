using System.Collections.Generic;
using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class ServerPlayerType : NetworkBehaviour
    {
        public SyncDictionary<TogglePlayer,bool> myDictionary = new(false);
        
        [ServerRpc]
        protected override void OnSpawned(bool asServer)
        {
            if (asServer)
                return;
            //Subscribing to changes made to the dictionary
            myDictionary.onChanged += OnDictionaryChanged;
        }
        
        [ObserversRpc]
        private void OnDictionaryChanged(SyncDictionaryChange<TogglePlayer, bool> change)
        {
            //This is called for everyone when the dictionary changes.
            //It will log out the Key, Value and operation
            Debug.Log($"Dictionary updated: {change}");
            EnablePlayersOnJoin();
        }
        private void ChangeMyDictionary(TogglePlayer t,bool vr)
        {
            //This will change or add a value to the dictionary
            myDictionary[t] = vr;
        }
        public void AddPlayerType(TogglePlayer player, bool playerType)
        {
            ChangeMyDictionary(player, playerType);
            EnablePlayersOnJoin();
            Debug.Log("added: "+player+" Vr: "+playerType);
        }
        public void EnablePlayersOnJoin()
        {
            foreach (TogglePlayer player in myDictionary.Keys)
            {
                player.Join(myDictionary[player]);
            }
        }
    }
}
