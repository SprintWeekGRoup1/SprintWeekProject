using System.Collections;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isInAir;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isInAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            StartCoroutine(CoyoteTime());
        }
    }
    private IEnumerator CoyoteTime()
    {
        isInAir = false;
        yield return new WaitForSecondsRealtime(0.5f);
        isInAir = true;
    }
}
