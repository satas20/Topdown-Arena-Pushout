using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackManager : MonoBehaviour
{
    private HealthScript healthScript;
    private Rigidbody2D rb;
    private PlayerManager playerManager;
    private PlayerMovement movementScript;
    private void Start()
    {
        healthScript = gameObject.GetComponent<HealthScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerManager = gameObject.GetComponent<PlayerManager>();
    }
    public void getKnocBack(float damage, GameObject skill)
    {
        Vector2 dir = (skill.gameObject.transform.position - gameObject.transform.position).normalized * -1;

        rb.velocity = dir * damage * healthScript.missingHealth();

    }
}
