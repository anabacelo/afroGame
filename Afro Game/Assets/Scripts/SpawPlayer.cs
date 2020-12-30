using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPlayer : MonoBehaviour
{
     [SerializeField] private GameObject[] playerPrefabs;
        [SerializeField] private Transform[] spawnPoint;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        //Spawna jogador 1
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("Personagem1")], spawnPoint[0].position, Quaternion.identity);

        
    }

}
