using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    [SerializeField,Tooltip("Tiempo en segundos")]private float _timerTime;
    private int minutes, seconds;

    private void Start()
    {
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        while (true)
        {
            if (_timerTime < 0)
            {
                _timerTime = 0;
            }
            _timerTime -= Time.deltaTime;
            minutes = (int)(_timerTime / 60f);
            seconds = (int)(_timerTime - minutes * 60f);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if(_timerTime == 0)
            {
                Destroy(this);
            }
            yield return null;

        }

    }

}
