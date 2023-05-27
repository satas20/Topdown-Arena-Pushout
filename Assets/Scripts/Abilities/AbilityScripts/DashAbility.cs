using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    public float dashVelocity;

    public override void Cast(GameObject parent)
    {
        //base.Cast(parent);

    }
    public override void Activate(GameObject parent){
        
        
        MoveToMouse movement = parent.GetComponent<MoveToMouse>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

       
        movement.speed = dashVelocity;
    }
    public override void BeginCooldown(GameObject parent)
    {
        MoveToMouse movement = parent.GetComponent<MoveToMouse>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
        movement.speed = 5;
    }
}
