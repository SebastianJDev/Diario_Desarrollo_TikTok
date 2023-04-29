using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerCam : MonoBehaviour
{

    private void Awake()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                CineMachineMovement.Instance.cinemachineVirtualCamera.m_Lens.OrthographicSize = 20;
                break;
            case "Gancho":
                CineMachineMovement.Instance.cinemachineVirtualCamera.m_Lens.OrthographicSize = 20;
                break;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CineMachineMovement.Instance.cinemachineVirtualCamera.m_Lens.OrthographicSize = 12;
    }
}
