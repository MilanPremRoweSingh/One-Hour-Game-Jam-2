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
        Vector3 jumpVelocity = Vector3.zero;
        if (Input.GetKeyDown("space"))
        {
            jumpVelocity = Vector3.up * terminalVelocity;
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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Murderer")
        {
            Die();
        }
    }
}
