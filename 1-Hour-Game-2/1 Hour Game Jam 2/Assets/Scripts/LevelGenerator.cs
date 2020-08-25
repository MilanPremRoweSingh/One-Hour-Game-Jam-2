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

    private float floorY = 0.0f;

    LinkedList<GameObject> floorList;
    public int maxFloors;
    public float minFloorDistance;
    public float maxFloorDistance;
    
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

        floorList.AddFirst(new Floor());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateFloor()
    {
        if (floorList.Count > maxFloors)
        {
            GameObject firstFloor = floorList.First.Value;
            floorList.RemoveFirst();
            firstFloor.transform.position = new Vector3(firstFloor.transform.position.x, floorY, firstFloor.transform.position.z);
            firstFloor.GetComponent<Floor>().Randomize();
            floorList.AddLast(firstFloor);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
