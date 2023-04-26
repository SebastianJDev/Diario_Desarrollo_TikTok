using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerMove movement = parent.GetComponent<PlayerMove>();
        movement.acceleration = dashVelocity;
    }

    public override void BeginCooldown(GameObject parent)
    {
        PlayerMove movement = parent.GetComponent<PlayerMove>();
        movement.acceleration = movement.normalAceleration;
    }
}
