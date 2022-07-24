using System.Threading.Tasks; //note that you need to include this if you want to use Task.Delay.
using UnityEngine;
using SpeechIO;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MenuIntroductionScript : MonoBehaviour
{
    SpeechIn speechIn;
    SpeechOut speechOut;
    void Start()
    {
        speechIn = new SpeechIn(onRecognized);
        speechOut = new SpeechOut();
        Dialog(); //Separately run asynchronous Dialog system.
    }

    private async void Dialog()
    {
    //     await Task.Delay(1000);
    //     await speechOut.Speak("Welcome to the Doctor.");
    //     await speechOut.Speak("Time to greet me");
    //     //Debug.Log("Hello!"); // system says hello
    //     await speechIn.Listen(new string[] { "hello", "hi", "hey" }); //wait for greet 
    //     //await Task.Delay(2000); // wait 2s 
        await speechOut.Speak("Select a level !");
        string level = await speechIn.Listen(new string[] { "one", "two", "three","four","repeat" }); //wait for response
        switch (level)
        { // switch response
            case "one":
                await speechOut.Speak("Selected level one.");
                LoadLevel(0);
                break;
            case "two":
                await speechOut.Speak("Selected level two.");
                LoadLevel(1);
                break;
            case "three":
                await speechOut.Speak("Selected level three.");
                LoadLevel(2);
                break;
            case "four":
                await speechOut.Speak("Selected level four.");
                LoadLevel(3);
                break;
            case "repeat":
                Dialog();
                break;
            default:
                Dialog();
                break;
        }
        speechIn.StopListening(); //terminates voice recognition
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    void onRecognized(string message)
    {
        Debug.Log("[" + this.GetType() + "]: " + message);
    }

    public void OnApplicationQuit()
    {
        speechIn.StopListening(); // [mac] do not delete this line!
        speechOut.Stop();
    }
}
