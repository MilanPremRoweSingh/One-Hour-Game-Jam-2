using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public static float maxHoleWidth;
    public static float minHoleWidth;
    public static float floorThickness;
    public static float scale;

    LevelGenerator levelGenerator;

    // x in [0,1];  y in world space 
    float holeWidth;
    float holeX;
    float height;

    GameObject leftSide;
    GameObject rightSide;
    BoxCollider trigger;

    void Start()
    {
        Vector3 position = transform.position;
        holeWidth = Random.Range(minHoleWidth, maxHoleWidth);
        holeX = Random.Range(holeWidth / 2.0f, 1 - holeWidth / 2.0f);
        
        // left side
        GameObject left = GameObject.CreatePrimitive(PrimitiveType.Cube);
        left.transform.localScale = new Vector3(scale, floorThickness, 1.0f);
        float leftX = scale*(-1.0f/2 - holeWidth/2 - (0.5f-holeX));
        left.transform.position = new Vector3(position.x + leftX, position.y, position.z);

        // right side
        GameObject right = GameObject.CreatePrimitive(PrimitiveType.Cube);
        right.transform.localScale = new Vector3(scale, floorThickness, 1.0f);
        float rightX = scale + leftX + scale*holeWidth;
        right.transform.position = new Vector3(position.x + rightX, position.y, position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
