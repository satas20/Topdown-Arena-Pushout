using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public float castTime;

    public GameObject instantiateable;      
    public virtual void Cast(GameObject parent) {
        MoveToMouse movement = parent.GetComponent<MoveToMouse>();
        PlayerManager playerManager = parent.GetComponent<PlayerManager>();

        playerManager.isCasting = true;
        aimToMouse(parent);
        
        movement.speed = 0;
    }
    public virtual void Activate(GameObject parent) {
        MoveToMouse movement = parent.GetComponent<MoveToMouse>();
        PlayerManager playerManager = parent.GetComponent<PlayerManager>();

        playerManager.isCasting = false;

        movement.speed = 5;
    }
    public virtual void BeginCooldown( GameObject parent){
       
    }

    private void aimToMouse(GameObject parent) {
        MoveToMouse movement = parent.GetComponent<MoveToMouse>();
        PlayerManager playerManager = parent.GetComponent<PlayerManager>();
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();

        Vector2 dir = movement.mousePos - parent.transform.position;
        if (dir.sqrMagnitude != 0)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
