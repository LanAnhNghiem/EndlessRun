using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Material []skyBoxes;
    float timer = 0.0f;
    int index = 0;

    private void Start()
    {
        RenderSettings.skybox = skyBoxes[0];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 60f)
        {
            if (index == 5)
                index = 0;
            RenderSettings.skybox = skyBoxes[index];
            index++;
            timer = 0f;
        }
    }
}
