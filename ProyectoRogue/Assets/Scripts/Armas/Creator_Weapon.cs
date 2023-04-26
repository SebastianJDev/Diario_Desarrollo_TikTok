using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Weapon")]
public class Creator_Weapon : ScriptableObject
{
    public string Name;
    public string Features;
    public GameObject prefab_Bullet;
    public float fireForce;
}
