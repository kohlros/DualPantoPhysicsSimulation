using UnityEngine;
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
        
        
        speech = new SpeechOut();
        Level level = GameObject.Find("Panto").GetComponent<Level>();
        await level.PlayIntroduction();
        // await speech.Speak("You are too");
        // await upperHandle.SwitchTo(player);
        await speech.Speak("Try out how that feels for a while.");
        
    }

    void OnApplicationQuit()
    {
        speech.Stop();
    }

}
