using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject followedObject;

    [SerializeField] float maxPosition;

    [SerializeField] float cameraSpeed;

    private float size;
    // Start is called before the first frame update
    void Start()
    {
        size = Vector3.Distance(transform.position, GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1, 0.5f), Camera.MonoOrStereoscopicEye.Mono));
    }

    // Update is called once per frame
    void Update()
    {
        var currentPos = transform.position;

        if(followedObject != null && followedObject.transform.position.x > currentPos.x)
        {
            if(currentPos.x + size < maxPosition)
            {
                currentPos.x = followedObject.transform.position.x;
                transform.position = currentPos;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(maxPosition, transform.position.y - 10), new Vector3(maxPosition, transform.position.y + 10));
    }
}
