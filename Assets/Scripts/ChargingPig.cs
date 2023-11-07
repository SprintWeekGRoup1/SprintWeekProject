using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChargingPig : EnemyController
{

    [SerializeField] protected float playerClose = 11f;
    [SerializeField] protected float chargeSpeed = 4f;

    private bool playerInRange = false;
    private float acceleration;

    protected override void Update()
    {
        DestroyEnemy();
        RangeFromPlayer();

        if (distanceFromPlayer < playerClose)
        {
            playerInRange = true;
        }
    }

    private void FixedUpdate()
    {
        if (playerInRange)
        {
            ChargeAtPlayer();
        }
    }


    protected virtual void ChargeAtPlayer()
    {
        Vector2 direction = new Vector2(-1f, 0f);
        acceleration += Time.deltaTime;
        rb2D.velocity = new Vector2(direction.x * chargeSpeed - acceleration, rb2D.velocity.y);
    }
}
