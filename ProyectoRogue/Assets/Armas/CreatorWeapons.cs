using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewWeapon",menuName = "Creator_Weapon",order =1)]
public class CreatorWeapons : ScriptableObject
{
    [SerializeField] private BulletTwo _bullet;
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;
    [SerializeField] private float _LivingTimeBullet;

    // Damage
    public int GetDamageWeapon() { return _damage; }
    public void SetDamageWeapon(int damage) { _damage = damage; }

    // Speed
    public int GetSpeedWeapon() { return _speed; }
    public void SetSpeedWeapon(int speed) { _speed = speed; }

    //LivingTimeBullet
    public float GetLivingTimeBullet() {  return _LivingTimeBullet; }
    public void SetLivingTimeBullet(float livingtime) { _LivingTimeBullet = livingtime; }

    public void Shoot(Transform shootPosition)
    {
        BulletTwo projectile = Instantiate(_bullet,shootPosition.position,shootPosition.rotation);
        projectile.SetBulletDirection(shootPosition, _damage,_speed);
    }

}
