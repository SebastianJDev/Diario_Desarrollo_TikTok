using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    void Awake()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
    }
}
