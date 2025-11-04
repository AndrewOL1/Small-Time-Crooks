using PurrNet;
using UnityEngine;

namespace AO.Scripts
{
    public class TpToStart : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GameObject spawnpoint = GameObject.Find("PC Spawn");
            transform.position = spawnpoint.transform.position;
        }

    }
}
