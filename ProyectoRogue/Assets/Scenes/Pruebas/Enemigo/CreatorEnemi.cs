using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewEnemy",menuName ="Enemy",order =2)]
public class CreatorEnemi : ScriptableObject
{
    [SerializeField] private  int _Health;
    [SerializeField] private  int _HealthMax;
    [SerializeField] private float _Speed;
    [SerializeField] private int _Damage;
    
    public CreatorEnemi(int healthMax,float speed,int damage)
    {
        _HealthMax = healthMax;
        _Speed = speed;
        _Damage = damage;
    }
    public int GetMaxHealth()
    {
        return _HealthMax;
    }

    public void SetMaxHealth(int HealthMax)
    {
        _HealthMax = HealthMax;
    }

    public int GetHealth()
    {
        return _Health;
    }
    public void SetHealth(int Health)
    {
        _Health = Health;
    }

  
    public void GetDamage(int dmg)
    {
        _Health -= dmg;
    }

    public float GetSpeed()
    {
        return _Speed;
    }
    public void SetSpeed(float speed)
    {
        _Speed = speed;
    }

    public int GetDamageEnemy() 
    {
        return _Damage;
    }

    public void SetDamageEnemy(int damage)
    {
        _Damage = damage;
    }
}
