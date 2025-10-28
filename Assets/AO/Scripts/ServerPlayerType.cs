using System.Collections.Generic;
using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class ServerPlayerType : NetworkBehaviour
    {
        public Dictionary<TogglePlayer,bool> PlayerType = new Dictionary<TogglePlayer,bool>();

        public void AddPlayerType(TogglePlayer player, bool playerType)
        {
            PlayerType.Add(player, playerType);
            EnablePlayersOnJoin();
        }

        public void EnablePlayersOnJoin()
        {
            foreach (TogglePlayer player in PlayerType.Keys)
            {
                player.Join(PlayerType[player]);
            }
        }
    }
}
