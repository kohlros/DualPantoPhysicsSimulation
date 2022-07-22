using UnityEngine;
using SpeechIO;
using DualPantoFramework;

public class Level3IntroScript : MonoBehaviour
{
    SpeechOut speech;
    async void Start()
    {   
        UpperHandle upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        GameObject player = GameObject.Find("Player"); 
        GameObject ForceField = GameObject.Find("NegativeParticleField");
        ForceField.transform.localScale = new Vector3 (1f,1f,1f); 

        speech = new SpeechOut();
        Level level = GameObject.Find("Panto").GetComponent<Level>();
        await level.PlayIntroduction();
        await speech.Speak("Versuche wie sich das anfühlt.");
        ForceField.transform.localScale = new Vector3 (100f,1f,100f);
        ForceField.GetComponent<ItHandle>().enabled = true;
        
    }

    void OnApplicationQuit()
    {
        speech.Stop();
    }

}
