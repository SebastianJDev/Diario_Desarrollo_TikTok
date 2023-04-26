using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private float health;

    private PlayerMove movimientoJugador;

    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    public void Start()
    {
        movimientoJugador = GetComponent<PlayerMove>();
        animator = GetComponent<Animator>();
    }

    public void TomarDa�o(float da�o)
    {
        health -= da�o;
    }

    public void TomarDa�o(float da�o,Vector2 posicion)
    {
        health -= da�o;
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        movimientoJugador.Rebote(posicion);
    }

    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador .sePuedeMover = true;
    }
}
