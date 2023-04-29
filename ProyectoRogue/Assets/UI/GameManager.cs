using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool IsPaused;
    public static GameManager Instance { get; private set; }
    public List<Personaje> personajes;


    private void Awake()
    {
       if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateGameState();
            ShowPausePanel();
        }
    }

    private void UpdateGameState()
    {
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void ShowPausePanel()
    {
        if (IsPaused)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }

    public bool IsGamePaused()
    {
        return IsPaused;
    }

    public void VolverAJugar()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        UpdateGameState();
        yield return new WaitForSecondsRealtime(1);
        UpdateGameState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

   
}
