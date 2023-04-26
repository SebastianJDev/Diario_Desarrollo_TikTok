using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logica_Armas : MonoBehaviour
{
    [SerializeField]private Transform firePoint;
    [SerializeField] private Creator_Weapon info;
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(info.prefab_Bullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * info.fireForce, ForceMode2D.Impulse);
        }
    }
}
