using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;
    float castTime;
    enum AbilityState {
        cast,
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    public KeyCode key;
    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key)&& !gameObject.GetComponent<PlayerManager>().isCasting)
                {
                    ability.Cast(gameObject);
                    state = AbilityState.cast;
                    castTime = ability.castTime;
                }
                break;
            case AbilityState.cast:
                if (castTime > 0)
                {
                    castTime -= Time.deltaTime;
                }
                else
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0){
                    activeTime -= Time.deltaTime;
                }
                else{
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0){
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
