using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected Transform playerPos;
    [SerializeField] protected GameObject mainCamera;

    protected Vector3 direction = new Vector3(-1f, 0, 0);

    protected float moveSpeed;
    protected float startMoveSpeed = 2f;
    protected float accelerate = 2f;
    protected float playerClose = 11f;
    protected float cameraSize, cameraOffset = 2f;
    protected bool playerInRange = false;


    protected virtual void Start()
    {
        cameraSize = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        moveSpeed = startMoveSpeed;
    }

    protected virtual void Update()
    {
        DestroyEnemy();

        float distance = Vector3.Distance(transform.position, playerPos.position);

        if (playerInRange)
        {
            AttackPlayer();
        }

        if (distance < playerClose)
        {
            playerInRange = true;
        }
    }

    protected virtual void AttackPlayer() { }

    protected void DestroyEnemy()
    {
        if (transform.position.x < mainCamera.transform.position.x - (cameraSize + cameraOffset))
        {
            Destroy(gameObject);
        }
    }

}
