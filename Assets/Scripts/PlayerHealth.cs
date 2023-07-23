using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{

    public HealthBar healthBar;
    public float currentHealth = 1;
    public bool alive = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for hit
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            UpdateHealth(-(EnemyBullet.damage));
            // Check if dead
            if (currentHealth <= 0)
            {
                alive = false;
            }
        }
    }

    private void UpdateHealth(float healthDelta)
    {
        currentHealth += healthDelta;
        healthBar.SetValue(currentHealth);
    }
}
