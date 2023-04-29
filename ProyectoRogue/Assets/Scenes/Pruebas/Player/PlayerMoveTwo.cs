using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMoveTwo : MonoBehaviour
{
    //Instancia
    public static PlayerMoveTwo instance;

    //Movement
    private Vector2 MoveInput;
    private Rigidbody2D rb;

    //Rotacion
    [SerializeField] private Transform Arrow;

    //Info
    public CreatorPlayer Info;

    //Rebote
    [SerializeField] private Vector2 velocidadRebote;
    public bool sePuedeMover = true;
    [SerializeField] private int TiempoSinControl;



    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (sePuedeMover)
        {
            Move();
        }
    }

    private void Update()
    {
        if(Info.GetHealth() <= 0)
        {
            Destroy(gameObject);
            Info.SetHealth(Info.GetMaxHealth());
        }
    }



    public void Move()
    {
        //Rotacion
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Arrow.up = (mousePos - (Vector2)transform.position).normalized;

        //Movement
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity += MoveInput * Info.GetSpeed() * Time.fixedDeltaTime;
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        Debug.Log("Rebote");
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, -velocidadRebote.y * puntoGolpe.y);
        StartCoroutine(PerderControl());
    }
    private IEnumerator PerderControl()
    {
        sePuedeMover = false;
        yield return new WaitForSeconds(TiempoSinControl);
        sePuedeMover = true;
    }
}
