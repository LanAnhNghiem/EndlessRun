using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {
    public GameObject[] floorPrefabs;
    Transform player;
    float spawnZ = 0.0f;
    float floorLength;
    int numOfFloors = 6;
    List<GameObject> activeFloors = new List<GameObject>();
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        floorLength = 10f;
        for(int i=0;i<numOfFloors;i++)
        {
            SpawnFloor();
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(player.position.z - floorLength > (spawnZ - floorLength * numOfFloors))
        {
            SpawnFloor();
            RemoveFloor();
        }
	}

    void SpawnFloor(int prefabIndex = 0)
    {
        GameObject gameObj = Instantiate(floorPrefabs[0]) as GameObject;
        gameObj.transform.SetParent(transform);
        gameObj.transform.position = new Vector3(0f, gameObj.transform.position.y);
        gameObj.transform.position = Vector3.forward * spawnZ;
        spawnZ += floorLength;
        activeFloors.Add(gameObj);
    }

    void RemoveFloor()
    {
        Destroy(activeFloors[0]);
        activeFloors.RemoveAt(0);
    }
}
