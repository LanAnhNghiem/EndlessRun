using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public GameObject[] ballPrefabs;
    Transform player;
    List<GameObject> activeBalls = new List<GameObject>();
    float spawnZ = 20.0f;
    float MIN = 1.0f;
    float MAX = 20.0f;
    int numOfBalls = 10;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        for(int i=0;i<numOfBalls;i++)
        {
            SpawnBall();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(player.position.z > activeBalls[1].transform.position.z)
        {
            SpawnBall();
            RemoveBall();
        }
        if (activeBalls.Count < numOfBalls)
            SpawnBall();
	}

    void SpawnBall()
    {
        GameObject gameObj = Instantiate(ballPrefabs[Random.Range(0,1)]) as GameObject;
        gameObj.transform.SetParent(transform);
        gameObj.transform.position = new Vector3(Random.Range(-4f, 4f), 2.5f, spawnZ);
        spawnZ += Random.Range(MIN, MAX);
        activeBalls.Add(gameObj);
    }
    void RemoveBall()
    {
        Destroy(activeBalls[0]);
        activeBalls.RemoveAt(0);
    }

}
