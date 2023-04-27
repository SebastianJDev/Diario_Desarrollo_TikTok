using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private GameObject Boss;

    private void Start()
    {
        Debug.Log("Start - SpawnBoss");
        Instantiate(Boss,transform.position,Quaternion.identity);
    }
}
