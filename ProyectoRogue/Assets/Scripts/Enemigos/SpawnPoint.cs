using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemy;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 1f, 5f);
    }

    void SpawnEnemies()
    {
        int enemiIndex = Random.Range(0, enemy.Length);
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy[enemiIndex], spawnPoints[index].position,Quaternion.identity);
    }
}
