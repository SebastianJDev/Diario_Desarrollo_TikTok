using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineMovement : MonoBehaviour
{
    public static CineMachineMovement Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineMultiChanelPerlin;

    private float tiempoMovimiento;
    private float tiempoMovimientoTotal;
    private float intencidadInicial;

    private Transform target;

    private void Awake()
    {
        Debug.Log("Awake - CineMachine");
        if (CineMachineMovement.Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineMultiChanelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        Debug.Log("Start - CineMachine");
        target =  GameObject.FindGameObjectWithTag("Player").transform;
        cinemachineVirtualCamera.Follow = target;
    }

    public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    {
        cinemachineMultiChanelPerlin.m_FrequencyGain = frecuencia;
        cinemachineMultiChanelPerlin.m_AmplitudeGain = intensidad;
        intencidadInicial = intensidad;
        tiempoMovimientoTotal = tiempo;
        tiempoMovimiento = tiempo;
    }

    private void Update()
    {
        if(tiempoMovimiento > 0)
        {
            tiempoMovimiento -= Time.deltaTime;
            cinemachineMultiChanelPerlin.m_AmplitudeGain = Mathf.Lerp(intencidadInicial, 0, 1 - (tiempoMovimiento / tiempoMovimientoTotal));
        }
    }
}
