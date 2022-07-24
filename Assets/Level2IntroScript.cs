using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechIO;
using DualPantoFramework;

public class Level2IntroScript : MonoBehaviour
{
    SpeechOut speech;
    // Start is called before the first frame update
    async void Start()
    {
        speech = new SpeechOut();
        await speech.Speak("The field is now uniform. See how that feels.");
        await speech.Speak("Go to the menu by saying menu");
        await speech.Speak("Go to the next experiment by saying next");
    }

    void OnApplicationQuit()
    {
        speech.Stop();
    }
}
