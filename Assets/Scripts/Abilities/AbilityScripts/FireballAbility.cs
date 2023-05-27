using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireballAbility : Ability
{
    public override void Cast(GameObject parent)
    {
        base.Cast(parent);
    }

    public float bulletForce;
    public override void Activate(GameObject parent)
    {
        base.Activate(parent);
        Transform firePoint = parent.transform.Find("firePoint");
        Debug.Log("fireball");

        GameObject bullet = Instantiate(instantiateable, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        BulletScript bulletScript = bullet.GetComponent<BulletScript>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
    public override void BeginCooldown(GameObject parent)
    {
        
    }
}
