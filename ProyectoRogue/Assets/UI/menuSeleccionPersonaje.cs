using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuSeleccionPersonaje : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;
    [SerializeField] private TextMeshProUGUI stats;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");
        if (index > gameManager.personajes.Count - 1)
        {
            index = 0;
        }

        CambiarPantalla();
    }

    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = gameManager.personajes[index].Imagen;
        nombre.text = gameManager.personajes[index].Nombre;
        stats.text = gameManager.personajes[index].Stats;
    }

    public void SiguientePersonaje()
    {
        if (index  == gameManager.personajes.Count - 1) 
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        CambiarPantalla();
    }
    public void AnteriorPersonaje()
    {
        if (index == 0)
        {
            index = gameManager.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarPantalla();
    }
}
