using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay;
    [SerializeField] private float destroyDelay;

    private Rigidbody2D rb;
    private float fallGravity = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlatformFallDown());
            StartCoroutine(PlatformDestroy());
        }
    }

    private IEnumerator PlatformFallDown()
    {
        yield return new WaitForSecondsRealtime(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = fallGravity;
    }

    private IEnumerator PlatformDestroy()
    {
        yield return new WaitForSecondsRealtime(destroyDelay);
        Destroy(gameObject);
    }
}
