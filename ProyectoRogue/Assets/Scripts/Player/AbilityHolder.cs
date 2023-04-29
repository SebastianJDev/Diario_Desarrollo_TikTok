using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public List<Ability> Abilities;
    float cooldownTime;
    float activateTime;
    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    public List<KeyCode>Key;

    void Update()
    {
            switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(Key[0]))
                {
                    Abilities[0].Activate(gameObject);
                    state = AbilityState.active;
                    activateTime = Abilities[0].activeTime;
                }
                break;
            case AbilityState.active:
                if(activateTime > 0)
                {
                    activateTime -= Time.deltaTime;
                }
                else
                {
                    Abilities[0].BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = Abilities[0].cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if(cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
}
