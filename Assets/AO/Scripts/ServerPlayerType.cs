using System.Collections.Generic;
using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class ServerPlayerType : NetworkBehaviour
    {
        public Dictionary<int,bool> PlayerType = new Dictionary<int,bool>();

        public void AddPlayerType(int playerID, bool playerType)
        {
            PlayerType.Add(playerID, playerType);
        }
    }
}
