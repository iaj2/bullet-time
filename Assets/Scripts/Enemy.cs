using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Transform player; //drag player into field to target player
    public float speed;
    public float rotateSpeed;

    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    private void FixedUpdate()
    {
        //move forwards
        Vector2 direction = transform.up;
        rb.velocity = direction * speed;
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
}
