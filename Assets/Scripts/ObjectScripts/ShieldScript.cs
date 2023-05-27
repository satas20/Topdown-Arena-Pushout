using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")){

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            

            Vector2 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized * 1;

            rb.velocity = dir* rb.velocity.magnitude;
            //Destroy(collision.gameObject);
        }
    }
   
}
