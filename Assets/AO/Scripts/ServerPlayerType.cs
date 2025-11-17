using System.Collections.Generic;
using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class ServerPlayerType : NetworkBehaviour
    {
        [SerializeField] private SyncDictionary<TogglePlayer,bool> playerType = new(true);
        
        protected override void OnSpawned()
        {
            //Subscribing to changes made to the dictionary
            playerType.onChanged += OnDictionaryChanged;
        }
        
        [ObserversRpc]
        private void OnDictionaryChanged(SyncDictionaryChange<TogglePlayer, bool> change)
        {
            //This is called for everyone when the dictionary changes.
            //It will log out the Key, Value and operation
            Debug.Log($"Dictionary updated: {change}");
            //EnablePlayersOnJoin();
        }
        public void AddPlayerType(TogglePlayer player, bool playerTypeBool)
        {
            playerType[player] = playerTypeBool;
        }
        private void EnablePlayersOnJoin()
        {
            foreach (var player in playerType.Keys)
            {
                player.Join(playerType[player]);
            }
        }
    }
}
