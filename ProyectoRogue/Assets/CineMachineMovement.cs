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

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineMultiChanelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    {
        cinemachineMultiChanelPerlin.m_AmplitudeGain = intensidad;
        cinemachineMultiChanelPerlin.m_FrequencyGain = frecuencia;
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
