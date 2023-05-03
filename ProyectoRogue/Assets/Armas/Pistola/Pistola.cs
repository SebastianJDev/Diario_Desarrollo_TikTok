using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] private CreatorWeapons _weapon;
    [SerializeField] private Transform _shootPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _weapon.Shoot(_shootPosition);
        }
    }
}
