using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewWeapon",menuName = "Weapon",order =1)]
public class CreatorWeapons : ScriptableObject
{
    [SerializeField]private int _damage;
    public CreatorWeapons(int damage)
    {
        _damage = damage;
    }

    public int GetDamage() 
    {
        return _damage;
    }
    public void SetDamage(int damage)
    {
        _damage = damage;
    }

}
