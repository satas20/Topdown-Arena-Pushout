using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float speed = 5f;
    public Vector3 target;
    public Vector3 dir;
    public Vector3 mousePos;
    private PlayerManager playerManager;
    
    void Start()
    {
        PlayerManager playerManager = gameObject.GetComponent<PlayerManager>();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerManager playerManager = gameObject.GetComponent<PlayerManager>();

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (playerManager.canMove){moveToClick();}
        if (! playerManager.isCasting){lookDir();}    
    }
    private void moveToClick() {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void lookDir(){

        dir = target - transform.position;
        if (dir.sqrMagnitude != 0)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}