using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float damage;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("EnemyHit");
            HealthScript healthScript = collision.gameObject.GetComponent<HealthScript>();
            KnockbackManager knocBackManager = collision.gameObject.GetComponent<KnockbackManager>();

            knocBackManager.getKnocBack(damage,gameObject);
            healthScript.takeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
