using UnityEngine;

public class ChargingPig : EnemyController
{
    [SerializeField] protected float playerClose;
    [SerializeField] private float acceleration;

    private bool playerInRange = false;

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
