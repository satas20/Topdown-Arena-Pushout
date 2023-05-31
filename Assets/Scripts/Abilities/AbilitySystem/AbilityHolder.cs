using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AbilityHolder : NetworkBehaviour
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
        if (!IsOwner) return;
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key)&& !gameObject.GetComponent<PlayerManager>().isCasting)
                {
                    RequestCastServerRpc();
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
                    RequestActivateServerRpc();
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
                    RequestCooldownServerRpc();
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
    [ServerRpc]
    private void RequestCastServerRpc(){
        CastClientRpc();
    }
    [ServerRpc]
    private void RequestActivateServerRpc()
    {
        ActivateClientRpc();
    }
    [ServerRpc]
    private void RequestCooldownServerRpc()
    {
        CooldownClientRpc();
    }

    [ClientRpc]
    private void CastClientRpc(){
        if(!IsOwner)ability.Cast(gameObject);
    }
    [ClientRpc]
    private void ActivateClientRpc()
    {
        if (!IsOwner) ability.Activate(gameObject);
    }
    [ClientRpc]
    private void CooldownClientRpc()
    {
        if (!IsOwner) ability.BeginCooldown(gameObject);
    }

}
