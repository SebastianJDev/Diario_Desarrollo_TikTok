using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    //Info
    public CreatorEnemi Info;
    private int _Health;

    //Animator
    private Animator _anim;

    //Target
    private Transform _target;

    //Movimiento
    private Rigidbody2D _rb;

    //Line OFsite
    [SerializeField] private float _lineOfSite;

    //Rotacion
    [SerializeField] private Transform _transform;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _Health = Info.GetHealth();
    }

    private void Start()
    {
        _target = PlayerMoveTwo.instance.transform;
    }

    private void FixedUpdate()
    {
        float distanceFromPLayer = Vector2.Distance(_target.position, _rb.transform.position);
        
        //Rotate
        Vector2 targetV = _target.position;
        _transform.up = (targetV - (Vector2)transform.position).normalized;
        if(distanceFromPLayer < _lineOfSite)
        {
            _rb.transform.position = Vector2.MoveTowards(_rb.transform.position, _target.position, Info.GetSpeed() * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                BulletTwo bullet = other.gameObject.GetComponent<BulletTwo>();
                _Health -= bullet.Info.GetDamageWeapon();
                CineMachineMovement.Instance.MoverCamara(1f, 1f, 0.3f);
                _anim.SetTrigger("Damage");
                Destroy(other.gameObject);
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                _rb.velocity = new Vector2(0, 0);
                PlayerMoveTwo _player = other.gameObject.GetComponent<PlayerMoveTwo>();
                _player.Rebote(other.GetContact(0).normal);
                _player._Health -= Info.GetDamageEnemy();
                CineMachineMovement.Instance.MoverCamara(5f,5f,0.5f);
                break;
        }
    }

    public void Update()
    {
        if(_Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lineOfSite);
    }
}
