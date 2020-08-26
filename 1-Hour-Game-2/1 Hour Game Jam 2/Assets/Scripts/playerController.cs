using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float terminalVelocity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = 0f;
        //rigidBody.drag = GetDragFromAcceleration(Physics.gravity.magnitude, terminalVelocity);
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
            moveDirection += new Vector3(0, 2.5f);
        }
        float sign = Mathf.Round(Input.GetAxis("Horizontal"));
        //moveDirection += new Vector3(sign * terminalVelocity - rigidBody.velocity.x, 0);
        Vector3 velocity = Vector3.right * sign * terminalVelocity;
        rigidBody.velocity = new Vector3(velocity.x, rigidBody.velocity.y);

        rigidBody.AddForce(moveDirection, ForceMode.VelocityChange);
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
