using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 targetOffset;
    public float startZDist = 10;
    [Range(0,0.2f)]
    public float smoothTime;

    private float downVelocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + targetOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref downVelocity, smoothTime);
        transform.position = newPosition;
    }
}
