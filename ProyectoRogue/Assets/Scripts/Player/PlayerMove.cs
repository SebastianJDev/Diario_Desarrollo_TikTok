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
    public  List<GameObject> Armas = new List<GameObject>();

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
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
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
        CambiarArma();
       
    }
    void ProccesInput()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        arrow.up = (mousePos - (Vector2)transform.position).normalized;
    }
    public void Move()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity += movementInput * acceleration * Time.fixedDeltaTime;
    }

    void CambiarArma()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Armas[0].gameObject.SetActive(true);
            Armas[1].gameObject.SetActive(false);
            Armas[2].gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Armas[1].gameObject.SetActive(true);
            Armas[0].gameObject.SetActive(false);
            Armas[2].gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Armas[2].gameObject.SetActive(true);
            Armas[0].gameObject.SetActive(false);
            Armas[1].gameObject.SetActive(false);
        }
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        rb.velocity = new Vector2(-velocidadRebote.x * puntoGolpe.x, -velocidadRebote.y * puntoGolpe.y);
    }

    
}
