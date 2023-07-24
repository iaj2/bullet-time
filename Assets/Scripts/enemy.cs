using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Transform player; //drag player into field to target player
    public Transform firePoint; //drag empty game object FirePoint ici
    public GameObject enemyBulletPrefab; //drag enemy bullet prefab here
    public GameObject deadEnemy; //dead enemy prefab here
    public GameObject deadEffect;

    public static bool alive;

    public float speed = 2f;
    public float rotateSpeed = 5f;

    public float shootDistance = 5f;
    public float stopDistance = 3f;

    public float fireRate;
    private float timeToFire;
    public float fireForce = 20f;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        timeToFire = fireRate;
        alive = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            RotateToPlayer();

        }
        else if (!player)
        {
            GetTarget();
        }
        if (Vector2.Distance(player.position, transform.position) <= shootDistance)
        {
            Shoot();

        }

    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(player.position, transform.position) >= stopDistance)
        {
            //move forwards
            Vector2 direction = transform.up;
            rb.velocity = direction * speed;

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        
    }

    private void GetTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void RotateToPlayer()
    {
        Vector2 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            timeToFire = fireRate;

        }else
        {
            timeToFire -= Time.deltaTime;

        }


    }

    private void OnCollisionEnter2D(Collision2D other) //death
    {
        if(other.gameObject.CompareTag("Bullet")) 
        {
            alive = false;
            Instantiate(deadEnemy, transform.position, transform.localRotation);
            Instantiate(deadEffect, transform.position, transform.localRotation);
            Destroy(gameObject);
            PlayerDead.kills++;
            Bits.bits += 4;

        }
    }
}