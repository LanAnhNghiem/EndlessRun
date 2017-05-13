using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RockCollider : MonoBehaviour {
    public AudioSource audio;
    
    GameObject rock;
    float timer = 0;
    bool isCollide;
    private void Start()
    {
        rock = GameObject.Find("BrokenRock(Clone)");
        isCollide = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BrokenRock(Clone)")
        {
            GameObject gameObj = collision.gameObject;
            audio.Play();
            MeshCollider []collider = gameObj.GetComponentsInChildren<MeshCollider>();
            for(int i=0;i<collider.Length;i++)
            {
                collider[i].enabled = true;
                collider[i].convex = true;
            }
            StartCoroutine(Wait(3f));
            

        }
    }
    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);   //Wait
        SceneManager.LoadScene("OverScene");
    }
}
