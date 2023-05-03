using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    public CreatorWeapons Info;
    private Rigidbody2D _rb;
    private int _speed;
    private float _damage;
    private float _time;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _time = Info.GetLivingTimeBullet();
        Destroy(gameObject,_time);
    }
    public void SetBulletDirection(Transform shootposition,int damage,int speed)
    {
        _speed = speed;
        _damage = damage;
        _rb.AddForce(shootposition.up * _speed, ForceMode2D.Impulse);
    }

}
