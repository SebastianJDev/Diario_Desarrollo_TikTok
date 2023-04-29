using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField, Tooltip("Tiempo en segundos")] private float TimerTime;

    private int minutes, seconds;

    private void Update()
    {
        TimerTime -= Time.deltaTime;
        
        if(TimerTime < 0) TimerTime = 0;

        minutes = (int)(TimerTime / 60f);
        seconds = (int)(TimerTime - minutes * 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        if(TimerTime == 0)
        {
            //Lanzar Evento
        }
    }
}
