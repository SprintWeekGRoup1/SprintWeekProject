using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public int damage = 1;

    [SerializeField] protected Transform playerPos;
    [SerializeField] protected GameObject mainCamera;
    [SerializeField] protected float direction;

    protected float cameraSize, cameraOffset = 2f;
    protected float distanceFromPlayer;
    protected Rigidbody2D rb2D;

    private PlayerHealth playerHealth;

    protected virtual void Start()
    {
        cameraSize = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        rb2D = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        if (direction > 0f)
        {
            Vector3 newLocalScale = transform.localScale;
            newLocalScale.x *= -1f;
            transform.localScale = newLocalScale;
        }
    }

    protected abstract void Update();

    protected virtual void RangeFromPlayer()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, playerPos.position);
    }

    protected void DestroyEnemy()
    {
        if (transform.position.x < mainCamera.transform.position.x - (cameraSize + cameraOffset))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
