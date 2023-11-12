using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{

    [SerializeField] protected Transform playerPos;
    [SerializeField] protected GameObject mainCamera;
    [SerializeField] protected float direction;

    protected float cameraSize, cameraOffset = 2f;
    protected float distanceFromPlayer;
    protected Rigidbody2D rb2D;

    protected virtual void Start()
    {
        cameraSize = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        rb2D = GetComponent<Rigidbody2D>();

        if (direction > 0f)
        {
            Vector3 newLocalScale = transform.localScale;
            newLocalScale.x *= -direction;
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

}
