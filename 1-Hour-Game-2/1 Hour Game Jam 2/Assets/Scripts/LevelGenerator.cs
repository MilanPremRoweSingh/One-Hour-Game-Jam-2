using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelGenerator : MonoBehaviour
{
    public GameObject player;
    public Camera cam;

    public GameObject floorPrefab;

    public static LevelGenerator levelGenerator = null;

    LinkedList<GameObject> floorList;
    
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(levelGenerator == null, "levelGenerator is a smelly ugly singleton made with sticks");
        levelGenerator = this;

        floorList = new LinkedList<GameObject>();

        Floor.maxHoleWidth = 0.25f;
        Floor.minHoleWidth = 0.2f;
        Floor.floorThickness = 0.25f;
        Floor.scale = 2 * cam.orthographicSize * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
