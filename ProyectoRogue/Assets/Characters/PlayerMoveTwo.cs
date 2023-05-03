using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveTwo : MonoBehaviour
{
    //Instancia
    public static PlayerMoveTwo instance;
    public int _Health;

    //Movement
    private Vector2 _MoveInput;
    private Rigidbody2D _rb;

    //Rotacion
    [SerializeField] private Transform _Weapon;

    //Info
    public CreatorPlayer Info;

    //Rebote
    [SerializeField] private Vector2 _velocidadRebote;
    public bool sePuedeMover = true;
    [SerializeField] private int _TiempoSinControl;



    private void Awake()
    {
        instance = this;
        _rb = GetComponent<Rigidbody2D>();
        _Health = Info.GetHealth();
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
        if(_Health <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Info.Dash(_rb,_MoveInput);
        }
    }



    public void Move()
    {
        //Rotacion
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _Weapon.up = (mousePos - (Vector2)transform.position).normalized;

        //Movement
        _MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.velocity += _MoveInput * Info.GetSpeed() * Time.fixedDeltaTime;
    }

    public void Rebote(Vector2 puntoGolpe)
    {
        Debug.Log("Rebote");
        _rb.velocity = new Vector2(-_velocidadRebote.x * puntoGolpe.x, -_velocidadRebote.y * puntoGolpe.y);
        StartCoroutine(PerderControl());
    }
    private IEnumerator PerderControl()
    {
        sePuedeMover = false;
        yield return new WaitForSeconds(_TiempoSinControl);
        sePuedeMover = true;
    }
}
