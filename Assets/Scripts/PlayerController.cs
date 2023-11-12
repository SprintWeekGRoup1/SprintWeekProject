using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject pauseObj;
    [SerializeField] private float coyoteTime;

    public float Speed = 10f;
    public float JumpingPower = 10f;

    private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;

    private bool isFacingRight = true;
    private bool pauseActive;
    private bool isJumping;

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
        if (!isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsOnGroundLayer(other))
        {
            StopCoroutine(CoyoteTime());
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsOnGroundLayer(other) && gameObject.activeInHierarchy)
        {
            StartCoroutine(CoyoteTime());
        }
    }

    private bool IsOnGroundLayer(Collider2D collider)
    {
        return (groundLayer.value & (1 << collider.gameObject.layer)) != 0;
    }

    private IEnumerator CoyoteTime()
    {
        yield return new WaitForSecondsRealtime(coyoteTime);
        isJumping = true;
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
}
