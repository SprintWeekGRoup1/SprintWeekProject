using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatorObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; // Increase for more rotation speed
    [SerializeField] private float rotationDirection; // Values 1 or -1 for different rotation directions

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * rotationDirection));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // kill or damage player here
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
