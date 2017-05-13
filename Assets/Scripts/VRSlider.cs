using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class VRSlider : MonoBehaviour {

    public float fillTime = 10.0f;
    public int index;
    Slider slider;
    float timer;
    bool gazedAt;//true when looking at the Slider
    Coroutine fillBarRoutine;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        if (slider == null)
            Debug.Log("Please add the Slider Component!");
	}
	

    public void PointerEnter()
    {
        gazedAt = true;
        fillBarRoutine = StartCoroutine(FillBar());
    }

    public void PointerExit()
    {
        gazedAt = false;
        if (fillBarRoutine != null)
        {
            StopCoroutine(fillBarRoutine);
        }
        timer = 0f;
        slider.value = 0f;
    }

    private IEnumerator FillBar()
    {
        timer = 0f;
        while (timer < fillTime)
        {
            timer += Time.deltaTime;
            slider.value = timer/fillTime;
            yield return null;

            if (gazedAt)
                continue;
            timer = 0f;
            slider.value = 0f;
            yield break;
        }

        OnBarFilled();
    }

    void OnBarFilled()
    {
        if (index == 0)
            SceneManager.LoadScene("PlayScene");
        else
            Application.Quit();
    }
}
