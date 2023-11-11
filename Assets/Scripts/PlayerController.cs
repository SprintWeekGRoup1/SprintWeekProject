using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform detectGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject pauseObj;
    [SerializeField] private float coyoteTime;

    public float Speed = 10f;
    public float JumpingPower = 10f;

    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;

    private bool isFacingRight = true;
    private bool pauseActive;
    private bool isGrounded;
    private float coyoteTimeCounter = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * Speed, rb.velocity.y);
    }

    void Update()
    {
        Flip();
        CoyoteTime();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void PlayerJump()
    {
        isGrounded = GroundedCheck();

        if (isGrounded || coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
        }
    }
    public void PauseMenu()
    {
        if (!pauseActive)
        {
            pauseObj.SetActive(true);
            Time.timeScale = 0;
            pauseActive = true;
        }
        else
        {
            pauseObj.SetActive(false);
            Time.timeScale = 1f;
            pauseActive = false;
        }
    }
    private void Flip()
    {
        if (isFacingRight && movement.x < 0f || !isFacingRight && movement.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool GroundedCheck()
    {
        // this create a check to detect if the player is on the ground in order to allow the player to jump
        return Physics2D.OverlapCircle(detectGround.position, 0.2f, groundLayer);
    }

    // Let's the player jump after not touching ground for a a brief grace period
    private void CoyoteTime()
    {
        if (!isGrounded)
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        else
        {
            coyoteTimeCounter = coyoteTime;
        }
    }
}
