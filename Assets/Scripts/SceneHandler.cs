using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "L1Cutscene")
            FindObjectOfType<AudioManager>().Play("Theme");

        else if (currentScene.name == "L1")
        {
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            FindObjectOfType<AudioManager>().Play("Move Choice");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void L1CutsceneEnd()
    {
        LoadScene("L1");
    }
}
