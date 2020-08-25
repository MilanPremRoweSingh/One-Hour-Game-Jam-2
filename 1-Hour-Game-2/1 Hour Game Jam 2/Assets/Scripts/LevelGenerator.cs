using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelGenerator : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
        
    private float floorY = 0.0f;

    LinkedList<GameObject> floorList;
    public int maxFloors;
    public float minFloorDistance;
    public float maxFloorDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        floorList = new LinkedList<GameObject>();

        Floor.maxHoleWidth = 0.25f;
        Floor.minHoleWidth = 0.2f;
        Floor.floorThickness = 0.25f;
        Floor.scale = 2 * cam.orthographicSize * cam.aspect;
        Floor.levelGenerator = this;

        GenerateFloor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateFloor()
    {
        if (floorList.Count > maxFloors)
        {
            GameObject floor = floorList.First.Value;
            floorList.RemoveFirst();
            floor.transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            floor.GetComponent<Floor>().Randomize();
            floorList.AddLast(floor);
        }
        else
        {
            GameObject floor = new GameObject(string.Format("Floor {0}", floorList.Count + 1));
            floor.transform.position = new Vector3(transform.position.x, floorY, transform.position.z);
            floor.AddComponent<Floor>();
            floorList.AddLast(floor);

        }
        floorY -= Random.Range(minFloorDistance, maxFloorDistance);
    }

}
