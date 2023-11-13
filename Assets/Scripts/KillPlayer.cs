using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("The player dies");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 
}

