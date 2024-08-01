using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D bulletRigidBody2D;
    [SerializeField] float bulletSpeed = 20f;
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        bulletRigidBody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

   
    void Update()
    {
        bulletRigidBody2D.velocity = new Vector2(xSpeed, 0f);
        transform.localScale = new Vector2(Mathf.Sign(xSpeed),1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy") 
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); 
    }
}
