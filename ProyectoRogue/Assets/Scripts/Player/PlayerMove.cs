using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Instancia
    public static PlayerMove instance;
    //Movimiento
    private Rigidbody2D rb;
    [SerializeField] private GameObject Arma;
    //Golpe
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebote;


    //Rotacion
    [SerializeField] public float normalAceleration;
    [SerializeField] public float acceleration;
    [SerializeField] public Vector2 movementInput;
    [SerializeField] public Transform arrow;

    


    void Awake()
    {
        Debug.Log("Awake - PlayerMove");
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Debug.Log("Start - PlayerMove");
        acceleration = normalAceleration;
    }
    void FixedUpdate()
    {
        if (sePuedeMover)
        {
            Move();
            
        }
    }
    void Update()
    {
        ProccesInput();
    }
    void ProccesInput()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        arrow.up = (mousePos - (Vector2)transform.position).normalized;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Arma.SetActive(true);
        }
    }
    public void Move()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity += movementInput * acceleration * Time.fixedDeltaTime;
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, -velocidadRebote.y * puntoGolpe.y);
    }

    
}
