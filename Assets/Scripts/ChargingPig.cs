using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingPig : EnemyController
{
    private bool animationPlayed;
    private float animationDelay = 1.5f;
    protected override void AttackPlayer()
    {
        if (!animationPlayed)
        {
            Debug.Log("Player charger animation!!!");
            StartCoroutine(WaitForAnimationToPlay());
        }
        else
        {
            ChargeThePlayer();
        }
    }

    IEnumerator WaitForAnimationToPlay()
    {
        yield return new WaitForSeconds(animationDelay);
        animationPlayed = true;
    }

    private void ChargeThePlayer()
    {
        moveSpeed += accelerate * Time.deltaTime;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
