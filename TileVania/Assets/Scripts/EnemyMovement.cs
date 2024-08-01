using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D gobberRigidBody2D;
    [SerializeField] float moveSpeed = 2f;

    void Start()
    {
        gobberRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        gobberRigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(gobberRigidBody2D.velocity.x)), 1f);
    }
}
