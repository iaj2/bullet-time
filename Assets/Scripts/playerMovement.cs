using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public Gun gun;

    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Movement input
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, 1 * speed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -1 * speed);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        // Mouse Input
        if (Input.GetMouseButtonDown(0))
        {
            gun.Fire();
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // Player/gun rotation
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }
}
