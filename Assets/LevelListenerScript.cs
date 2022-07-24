using System.Threading.Tasks; //note that you need to include this if you want to use Task.Delay.
using UnityEngine;
using SpeechIO;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelListenerScript : MonoBehaviour
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
        string voiceInput = await speechIn.Listen(new string[] {"menu","next"});
        switch (voiceInput)
        {
            case "menu":
                SceneManager.LoadScene(5);
                break;
            case "next":
                LoadNextLevel();
                break;
            default:
                SceneManager.LoadScene(5);
                break;
        }
    }

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if(currentScene <=3){
            SceneManager.LoadScene(currentScene +1);
        }else{
            SceneManager.LoadScene(5);
        }
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
