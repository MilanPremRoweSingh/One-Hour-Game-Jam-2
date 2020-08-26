using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public static float maxHoleWidth;
    public static float minHoleWidth;
    public static float floorThickness;
    public static float scale;
    public static LevelGenerator levelGenerator;

    // x in [0,1];  y in world space 
    float holeWidth;
    float holeX;
    float height;

    GameObject leftSide;
    GameObject rightSide;
    BoxCollider trigger;
    float triggerScale;
    bool hasGeneratedNext = false;

    void Start()
    {
        leftSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftSide.AddComponent<BoxCollider2D>().isTrigger = true;
        leftSide.tag = "Murderer";
        rightSide = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightSide.AddComponent<BoxCollider2D>().isTrigger = true;
        rightSide.tag = "Murderer";
        trigger = gameObject.AddComponent<BoxCollider>();
        trigger.isTrigger = true;
        trigger.transform.localScale = new Vector3(scale, floorThickness, 1.0f);
        Randomize();
    }

    public void Randomize()
    {
        hasGeneratedNext = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (!hasGeneratedNext)
        {
            levelGenerator.GenerateFloor();
            hasGeneratedNext = true;
        }
    }
}
