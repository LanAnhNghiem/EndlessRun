using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour {

    public GameObject []rockPrefabs;
    Transform player;
    List<GameObject> activeRocks = new List<GameObject>();
    float spawnZ = 10.0f;
    int numOfRocks = 5;
    float MIN = 20.0f;
    float MAX = 50.0f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        for(int i =0;i<numOfRocks;i++)
        {
            SpawnRock();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.z > activeRocks[2].transform.position.z)
        {
            SpawnRock();
            RemoveRock();
        }
	}

    void SpawnRock()
    {
        GameObject gameObj = Instantiate(rockPrefabs[0]) as GameObject;
        gameObj.transform.SetParent(transform);
        gameObj.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), -1f, spawnZ);
        spawnZ += Random.Range(MIN, MAX);
        activeRocks.Add(gameObj);
    }
    void RemoveRock()
    {
        Destroy(activeRocks[0]);
        activeRocks.RemoveAt(0);
    }
}
