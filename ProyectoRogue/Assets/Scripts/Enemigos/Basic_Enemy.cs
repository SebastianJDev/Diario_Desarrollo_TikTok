using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy : MonoBehaviour
{
    private Creator_Bullet info;
    [SerializeField] private int Healt = 10;
    private Animator animator;
    private Transform target;
    public float speed;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 Impulso;
    [SerializeField] private float TiempoSinControl;

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject XP;
    [SerializeField] private float lineOfsite;
    [SerializeField] private CineMachineMovement Cinemachines;

    public Transform enemy;


    private void Awake()
    {
        Debug.Log("Awake - Basic-Enemy");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log("Fin Awake - Basic-Enemy");

    }
    void Start()
    {
        Debug.Log("Start - Basic-Enemy");
        target = PlayerMove.instance.transform;
        Cinemachines = CineMachineMovement.Instance;
        Debug.Log("Fin Start - Basic-Enemy");

    }
    private void FixedUpdate()
    {
        float distanceFromPlayer = Vector2.Distance(target.position, rb.transform.position);
        //Rotate
        Vector2 targetV = target.position;
        enemy.up = (targetV - (Vector2)transform.position).normalized;
        if (distanceFromPlayer < lineOfsite)
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position,target.position,speed * Time.deltaTime);
        }
    }
    void Update()
    {
        if (Healt <= 0)
        {
            Destroy(this.gameObject);
            GameObject explosiones = Instantiate(explosion, transform.position, transform.rotation);
            GameObject xp = Instantiate(XP, transform.position, transform.rotation);
            Destroy(explosiones,0.75f);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Bullet":
                Healt -= other.gameObject.GetComponent<Bala>().info.Damage;
                animator.SetTrigger("Daño");
                Cinemachines.MoverCamara(2,2,0.5f);
                break;
        }        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch(other.gameObject.tag) 
        {
            case "Player":
                rb.velocity = new Vector2(0, 0);
                other.gameObject.GetComponent<HealthPlayer>().TomarDaño(20,other.GetContact(0).normal);
                animator.SetTrigger("Daño");
                Cinemachines.MoverCamara(4,4,0.9f);
                break;
            case "Gancho":
                Debug.Log("Activo Impulso Enemigo");
                animator.SetTrigger("Daño");
                Cinemachines.MoverCamara(4,4,0.9f);
                rb.velocity = new Vector2(Impulso.x * other.GetContact(0).normal.x, Impulso.y * other.GetContact(0).normal.y);
                StartCoroutine(Esperar());
                Healt -= 10;
                break;
        }
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(TiempoSinControl);
        rb.velocity = new Vector2(0, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfsite);
    }
}
