using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject prefabBulllet;
    [SerializeField] private int FireForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(prefabBulllet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * FireForce, ForceMode2D.Impulse);
        }
    }
}
