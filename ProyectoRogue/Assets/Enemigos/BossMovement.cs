using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    //Info
    public CreatorEnemi info;
    [SerializeField] private int _Health;

    //Animator
    private Animator _anim;

    //Movimiento
    private Rigidbody2D _rb;


    //Target
    private Transform _target;

    //Rotate
    public Transform _transform;

    // Ranges
    [SerializeField] private float _shootingRange;
    [SerializeField] private float _lineOfsite;

    //Bullets
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletParent;

    // Fire Rate
    [SerializeField] private float _fireRate;
    private float _nextFireTime;



    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _Health = info.GetHealth();
    }

    private void Start()
    {
         _target = PlayerMoveTwo.instance.transform;
    }

    private void FixedUpdate()
    {
        //Rotate
        Vector2 targetV = _target.position;
        _transform.up = (targetV -(Vector2)transform.position).normalized;

        //Shoot Distance
        float distanceFromPlayer = Vector2.Distance(_target.position, _rb.transform.position);
        if(distanceFromPlayer < _lineOfsite && distanceFromPlayer > _shootingRange)
        {
            _rb.transform.position = Vector2.MoveTowards(_rb.transform.position, _target.position, info.GetSpeed() * Time.deltaTime);
        }else if (distanceFromPlayer <= _shootingRange && _nextFireTime < Time.time)
        {
            Instantiate(_bullet, _bulletParent.transform.position, Quaternion.identity);
            _nextFireTime = Time.time + _fireRate;
        }
    }

    public void Update()
    {
        if(_Health <= 0)
        {
            Destroy(gameObject);
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
                _player.Info.TomarDañoPlayer(info.GetDamageEnemy());
                _player.Rebote(other.GetContact(0).normal);
                CineMachineMovement.Instance.MoverCamara(5f, 5f, 0.5f);
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _lineOfsite);
        Gizmos.DrawWireSphere(transform.position, _shootingRange);
    }
}
