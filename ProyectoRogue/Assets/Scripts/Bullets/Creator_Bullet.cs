using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Bullet")]
public class Creator_Bullet : ScriptableObject
{
    public float livingTime = 1f;

    public Color initialColor = Color.white;
    public Color finalColor;


    public int Damage;
}
