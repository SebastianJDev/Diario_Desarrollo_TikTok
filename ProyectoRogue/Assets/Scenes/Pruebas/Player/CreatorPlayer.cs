using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewCharacter", menuName = "Creator_Character", order =0)]
public class CreatorPlayer : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private string _name;


    public  CreatorPlayer(float speed, int maxHealth)
    {
        _speed = speed;
        _maxHealth = maxHealth;
    }

    public int GetMaxHealth() { return _maxHealth; }
    public void SetMaxHealth(int maxHealth) { _maxHealth = maxHealth; }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(float speed) 
    {
        _speed = speed;
    }

    public void TomarDaño(int damage)
    {
        _health -= damage;
    }

    


}
