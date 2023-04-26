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

    public void TomarDaño(float daño)
    {
        health -= daño;
    }

    public void TomarDaño(float daño,Vector2 posicion)
    {
        health -= daño;
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
