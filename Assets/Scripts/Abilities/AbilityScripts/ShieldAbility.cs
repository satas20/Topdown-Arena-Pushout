using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShieldAbility : Ability
{
    public override void Cast(GameObject parent)
    {
        //base.Cast(parent);
        
    }
    public override void Activate(GameObject parent)
    {
       GameObject shield = Instantiate(instantiateable,parent.transform.position,Quaternion.identity,parent.transform );
        
    }
    public override void BeginCooldown(GameObject parent)
    {
        GameObject shield = parent.transform.Find("shield(Clone)").gameObject;
        Destroy(shield);
    }
}
