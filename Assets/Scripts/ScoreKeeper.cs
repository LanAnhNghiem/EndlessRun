using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        
	}
	
    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;
    }
}
