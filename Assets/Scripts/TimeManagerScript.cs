using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{

    public bool isActive = true;
    public float timeForLevel = 30f;

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            timeForLevel -= Time.deltaTime; 
            if(timeForLevel < 0f){
                isActive = false;
                Debug.Log("Changing level...");
                ChangeLevel();
            }
        }        

    }

    void ChangeLevel(){
        GameObject.Find("LevelLoader").GetComponent<LevelLoaderScript>().LoadNextLevel();

    }
}
