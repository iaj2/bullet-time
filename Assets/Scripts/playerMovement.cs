using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public static float speed = 5f;
    public float currentHealth = 1;
    public bool alive = true;
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public Gun gun;

    public GameObject particles;
    private float particleCooldown = 1;

    public HealthBar healthBar;

    
    Vector2 mousePosition;

    private void UpdateHealth()
    {
        const float damage = 0.02f;
        currentHealth -= damage;
        healthBar.SetValue(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for hit
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            UpdateHealth();
            // Check if dead
            if (currentHealth <= 0)
            {
                alive = false;
            }

        }
    }
    private void FocusHeal()
    {
        if (Bits.bits > 0 && currentHealth < 1)
        {
            if (particleCooldown > 0)
            {
                Instantiate(particles, transform.position, transform.rotation);

                particleCooldown -= 1;
            } else if (particleCooldown < 0)
            {
                particleCooldown += 0.01f * Time.deltaTime;

            }
            
            Bits.bits -= 1 * Time.deltaTime;
            currentHealth += 0.01f * Time.deltaTime;
            healthBar.SetValue(currentHealth);
        }
        else if (Bits.bits <= 0)
        {
            Debug.Log("Out of bits!");

        }
        else if (currentHealth >= 1)
        {
            currentHealth = 1;
            Debug.Log("Health maxxed out.");

        }
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

        //healing
        if (Input.GetKey(KeyCode.F))
        {
            FocusHeal();

        }
    }

    void FixedUpdate()
    {
        // Player/gun rotation
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }
}
