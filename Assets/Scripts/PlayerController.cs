using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpingPower = 10f;
    public InputAction PlayerControls;

    private float horizontal;
    private bool isFacingRight = true;
    private Rigidbody2D rb;

    [SerializeField] private Transform detectGround;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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
