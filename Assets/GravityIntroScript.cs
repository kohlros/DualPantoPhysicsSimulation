using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechIO;
using DualPantoFramework;

public class GravityIntroScript : MonoBehaviour
{
    SpeechOut speech;
    // Start is called before the first frame update
    async void Start()
    {
        speech = new SpeechOut();
        Level level = GameObject.Find("Panto").GetComponent<Level>();
        await level.PlayIntroduction();
        GameObject.Find("Player").GetComponent<MeHandle>().enabled = true;
        GameObject.Find("Object").GetComponent<ItHandle>().enabled = true;
        GameObject.Find("Player").GetComponent<GravityScript>().enabled = true;
        GameObject.Find("Object").GetComponent<GravityItScript>().enabled = true;
        
    }

   void OnApplicationQuit()
   {
    speech.Stop();
   }
}
