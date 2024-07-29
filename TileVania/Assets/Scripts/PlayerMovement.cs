using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRB;
    [SerializeField] float playerSpeed = 5f;
    Animator myAnimator;
    [SerializeField] float playerJumpForce = 5f;
    CapsuleCollider2D playerCapsuleCollider2D;
    

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();  
        playerCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    { 
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * playerSpeed, playerRB.velocity.y);
        playerRB.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRB.velocity.x) > Mathf.Epsilon;

        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(playerRB.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRB.velocity.x), 1f);
        }
     }

    //player jumping 

    void OnJump(InputValue value)
    {
        // Checks whether the player is touching the Ground or not
        if (!playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            playerRB.velocity += new Vector2(0f, playerJumpForce);
        }

    }
}
