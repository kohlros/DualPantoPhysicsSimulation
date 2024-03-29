﻿using UnityEngine;
using SpeechIO;
using DualPantoFramework;

public class IntroductionManager : MonoBehaviour
{
    SpeechOut speech;
    private Vector3 zeroScale = new Vector3(0f,0f,0f);
    async void Start()
    {   
        UpperHandle upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        GameObject player = GameObject.Find("Player"); 
        //GameObject ForceField = GameObject.Find("NegativeParticleField");
        // "disable" the forcefield 
        //ForceField.transform.localScale = new Vector3 (1f,1f,1f); 

        speech = new SpeechOut();
        Level level = GameObject.Find("Panto").GetComponent<Level>();
        await level.PlayIntroduction();
        await speech.Speak("Versuche wie sich das anfühlt.");
        //ForceField.transform.localScale = new Vector3 (20f,20f,20f);
        // reanable the forceField
        
    }

    void OnApplicationQuit()
    {
        speech.Stop();
    }

}
