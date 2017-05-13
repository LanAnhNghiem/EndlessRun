using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverScoreDisplay : MonoBehaviour {

    Text score;
    ScoreAbsorber scoreAbsorber;
	// Use this for initialization
	void Start () {
        scoreAbsorber = FindObjectOfType<ScoreAbsorber>();
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Your score: " + scoreAbsorber.score;
	}
}
