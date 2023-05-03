using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewEnemy",menuName ="Creator_Enemy",order =2)]
public class CreatorEnemi : ScriptableObject
{
    [SerializeField] private  int _Health;
    [SerializeField] private float _Speed;
    [SerializeField] private int _Damage;
    
    // Health
    public int GetHealth() { return _Health; }
    public void SetHealth(int Health) { _Health = Health; }

    //Speed
    public float GetSpeed() { return _Speed; }
    public void SetSpeed(float speed) { _Speed = speed; }

    //Damage Enemy
    public int GetDamageEnemy() { return _Damage; }
    public void SetDamageEnemy(int damage) { _Damage = damage; }
}
