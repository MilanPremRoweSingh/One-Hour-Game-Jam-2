using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float speed = 1.5F;
    public float terminalVelocity = 5.0F;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = GetDragFromAcceleration(Physics.gravity.magnitude, terminalVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidBody.velocity.y > 0)
        {
            rigidBody.drag = 0;
        }
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown("space"))
        {
            moveDirection += new Vector3(0, 100f);
        };
        moveDirection += new Vector3(Input.GetAxis("Horizontal"), 0);
        moveDirection *= speed;

        rigidBody.AddForce(moveDirection);
    }

    private void FixedUpdate()
    {
        if (rigidBody.velocity.x > 5.0F)
        {
            rigidBody.velocity = new Vector2(5.0F, rigidBody.velocity.y);
        }
        else if (rigidBody.velocity.x < -5.0F)
        {
            rigidBody.velocity = new Vector2(-5.0F, rigidBody.velocity.y);
        }
    }

    public static float GetDrag(float aVelocityChange, float aFinalVelocity)
    {
        return aVelocityChange / ((aFinalVelocity + aVelocityChange) * Time.fixedDeltaTime);
    }

    public static float GetDragFromAcceleration(float aAcceleration, float aFinalVelocity)
    {
        return GetDrag(aAcceleration * Time.fixedDeltaTime, aFinalVelocity);
    }
}
