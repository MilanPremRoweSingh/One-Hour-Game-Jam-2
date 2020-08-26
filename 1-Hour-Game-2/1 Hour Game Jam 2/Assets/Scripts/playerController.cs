using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float terminalVelocity;
    private int jumpsUsed = 0;
    private Vector3 startPos;    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.drag = 0f;
        //rigidBody.drag = GetDragFromAcceleration(Physics.gravity.magnitude, terminalVelocity);

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidBody.velocity.y > 0)
        {
            rigidBody.drag = 0;
        }
        Vector3 jumpVelocity = Vector3.zero;
        if (Input.GetKeyDown("space"))
        {
            if (rigidBody.velocity.y <= 0f)
            {
                jumpVelocity = Vector3.up * (1f + jumpsUsed * 0.5f) * terminalVelocity;
                jumpsUsed++;
            }
        }
        float sign = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        Vector3 horzVelocity = Vector3.right * sign * terminalVelocity;
        rigidBody.velocity = new Vector3(horzVelocity.x, jumpVelocity.y > 0f ? jumpVelocity.y : rigidBody.velocity.y);
    }

    public static float GetDrag(float aVelocityChange, float aFinalVelocity)
    {
        return aVelocityChange / ((aFinalVelocity + aVelocityChange) * Time.fixedDeltaTime);
    }

    public static float GetDragFromAcceleration(float aAcceleration, float aFinalVelocity)
    {
        return GetDrag(aAcceleration * Time.fixedDeltaTime, aFinalVelocity);
    }

    public void Die()
    {
        transform.position = startPos;
        rigidBody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Murderer")
        {
            Die();
        }
        else if (other.gameObject.tag == "Hole")
        {
            if(other.transform.gameObject.transform.position.y < rigidBody.position.y) jumpsUsed = 0;
        }
    }
}
