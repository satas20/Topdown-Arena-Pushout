using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float forceDamping;
    [SerializeField] private Vector2 forceToAply;
    Vector2 moveForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToAply;
        handleForceDamping();
        rb.velocity = moveForce;
    }
    private void movePLayer(){

        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToAply;
        
    }
    private void handleForceDamping(){

        forceToAply /= forceDamping;
        if (Mathf.Abs(forceToAply.x) <= 0.01f && Mathf.Abs(forceToAply.y) <= 0.01f)
        {
            forceToAply = Vector2.zero;
        }
    }
    public void addForce(Vector2 force){
        forceToAply += force;

    }

}
