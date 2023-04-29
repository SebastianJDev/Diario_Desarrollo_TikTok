using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private Animator TransitionAnimator;
    [SerializeField] private float transitionTime = 1f;

    private void Awake()
    {
        TransitionAnimator = GetComponentInChildren<Animator>();
    }
    public void ComenzarJuego()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(sceneLoad(nextSceneIndex));
    }

    public IEnumerator sceneLoad(int sceneIndex)
    {
        TransitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
