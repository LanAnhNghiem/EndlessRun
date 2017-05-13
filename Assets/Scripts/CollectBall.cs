using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBall : MonoBehaviour {

    int scoreValue = 1;
    Transform vrCamera;
    private void Start()
    {
        vrCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BlueBall(Clone)")
        {
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, vrCamera.position, 2f);
            Destroy(other);
            ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
            scoreKeeper.IncreaseScore(scoreValue);
        }
        if (other.gameObject.name == "RedBall(Clone)")
        {
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
            other.gameObject.transform.position = Vector3.MoveTowards(other.gameObject.transform.position, vrCamera.position, 2f);
            Destroy(other);
            ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
            scoreKeeper.IncreaseScore(scoreValue * 3);
        }
    }
}
