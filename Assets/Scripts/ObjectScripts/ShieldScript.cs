using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")){

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.velocity *= -1; 

            //Destroy(collision.gameObject);
        }
    }
   
}
