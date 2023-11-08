using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingPig : EnemyController
{
    [SerializeField] protected float playerClose;
    [SerializeField] private float acceleration = 3f;

    private bool playerInRange = false;
    private float direction = -1f;

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
        rb2D.AddForce(new Vector2(direction * acceleration, 0), ForceMode2D.Force);
    }
}
