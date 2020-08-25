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
    float triggerScale;

    void Start()
    {
        leftSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
        triggerScale = -1.0f;
    }

    public void Randomize()
    {
        Vector3 position = transform.position;
        holeWidth = Random.Range(minHoleWidth, maxHoleWidth);
        holeX = Random.Range(holeWidth / 2.0f, 1 - holeWidth / 2.0f);

        leftSide.transform.localScale = new Vector3(scale, floorThickness, 1.0f);
        float leftX = scale * (-1.0f / 2 - holeWidth / 2 - (0.5f - holeX));
        leftSide.transform.position = new Vector3(position.x + leftX, position.y, position.z);

        rightSide.transform.localScale = new Vector3(scale, floorThickness, 1.0f);
        float rightX = scale + leftX + scale * holeWidth;
        rightSide.transform.position = new Vector3(position.x + rightX, position.y, position.z);
    }

    private void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        levelGenerator.GenerateFloor();
    }
}
