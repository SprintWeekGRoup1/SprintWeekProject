using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpingPower = 10f;

    private bool isFacingRight = true;
    private bool pauseActive;

    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;

    [SerializeField] private Transform detectGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject pauseObj;


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
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void PlayerJump()
    {
        if (isGrounded())
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

    private bool isGrounded()
    {
        // this create a check to detect if the player is on the ground in order to allow the player to jump
        return Physics2D.OverlapCircle(detectGround.position, 0.2f, groundLayer);
    }

}
