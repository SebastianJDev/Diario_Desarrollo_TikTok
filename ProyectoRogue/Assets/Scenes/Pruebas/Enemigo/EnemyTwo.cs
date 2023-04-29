using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    //Info
    public CreatorEnemi Info;

    //Target
    private Transform target;

    //Movimiento
    private Rigidbody2D rb;
    [SerializeField] private float lineOfSite;
    public Transform enemy;

    //Daño
    [SerializeField] private Vector2 Impulso;
    [SerializeField] private float TiempoSinControl;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //Animator
    }

    private void Start()
    {
        target = PlayerMoveTwo.instance.transform;
        //CineMachine
    }

    private void FixedUpdate()
    {
        float distanceFromPLayer = Vector2.Distance(target.position, rb.transform.position);
        
        //Rotate
        Vector2 targetV = target.position;
        enemy.up = (targetV - (Vector2)transform.position).normalized;
        if(distanceFromPLayer < lineOfSite)
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, target.transform.position, Info.GetSpeed() * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                Info.GetDamage(other.gameObject.GetComponent<BulletTwo>().Info.GetDamage());
                Destroy(other.gameObject);
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                rb.velocity = new Vector2(0, 0);
                other.gameObject.GetComponent<PlayerMoveTwo>().Info.TomarDaño(Info.GetDamageEnemy());
                other.gameObject.GetComponent<PlayerMoveTwo>().Rebote(other.GetContact(0).normal);
                break;
        }
    }

    public void Update()
    {
        if(Info.GetHealth() <= 0)
        {
            Destroy(gameObject);
            Info.SetHealth(Info.GetMaxHealth());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
