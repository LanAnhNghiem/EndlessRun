using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float speed = 3.0f;
    public bool isMove;
    CharacterController controller;
    Vector3 moveVector;
    bool turnLeft;
    bool moveForward;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        moveVector = Vector3.zero;
        moveVector.z = speed;
        moveForward = true;
        isMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isMove)
        {
            if (transform.eulerAngles.y <= 350 && transform.eulerAngles.y >= 300f)
            {
                print("turn left");
                turnLeft = true;
                moveForward = false;
            }
            if (transform.eulerAngles.y >= 10 && transform.eulerAngles.y <= 60f)
            {
                print("turn right");
                turnLeft = false;//turn right
                moveForward = false;
            }
            if (transform.eulerAngles.y > 350 || transform.eulerAngles.y < 10)
            {
                moveForward = true;
                print("forward");
            }

            if (turnLeft)
            {
                if (!moveForward)
                    moveVector.x -= 0.01f;
                else
                    moveVector.x = 0;
            }
            else
            {
                if (!moveForward)
                    moveVector.x += 0.01f;
                else
                    moveVector.x = 0;
            }
        }
        else
        {
            moveVector.x = moveVector.z = 0;
        }
        controller.Move(moveVector * Time.deltaTime);
       
    }
}
