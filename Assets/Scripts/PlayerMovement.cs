using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = new GameObject();
        Debug.Log(player.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerControl(GameObject player)
    {

    }
}
