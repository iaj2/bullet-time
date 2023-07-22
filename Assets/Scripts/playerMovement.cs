using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static float speed = 7f;
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public Gun gun;

    public GameObject IdleAnim;
    public GameObject FireAnim;
    private float animCoolDown = 5f;

    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        IdleAnim.SetActive(true);
        FireAnim.SetActive(false);
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
            if (animCoolDown > 0)
            {
                FireAnim.SetActive(true);
                IdleAnim.SetActive(false);
                animCoolDown -= Time.deltaTime;
                Debug.Log("Fires");
            } else if (animCoolDown <= 0)
            {
                IdleAnim.SetActive(true);
                FireAnim.SetActive(false);
                animCoolDown = 5f;
            }   
        }
        else
        {
            IdleAnim.SetActive(true);
            FireAnim.SetActive(false);
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
