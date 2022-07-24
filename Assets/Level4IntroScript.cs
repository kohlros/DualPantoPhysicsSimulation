using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SpeechIO;
using DualPantoFramework;

public class Level4IntroScript : MonoBehaviour
{
    SpeechOut speech;

    async void Start()
    {
        speech = new SpeechOut();
        // speech.SetLanguage(SpeechBase.LANGUAGE.GERMAN);
        await speech.Speak("Du bist nun in einem Magnetfeld. Bewege dich vorsichtig im Kreis.");
    }


    void OnApplicationQuit()
    {
        speech.Stop();
    }
}
