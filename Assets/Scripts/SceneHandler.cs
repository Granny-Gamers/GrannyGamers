using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Runs at the start of the program.
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Handles the background audio for each scene.
        if (currentScene.name == "L1Cutscene")
            FindObjectOfType<AudioManager>().Play("Theme");

        else if (currentScene.name == "L1")
        {
            FindObjectOfType<AudioManager>().StopPlaying("Theme");
            FindObjectOfType<AudioManager>().Play("Move Choice");
        }
    }

    // Loads the scene given by sceneName
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Loads the post level 1 cutscene.
    public void L1CutsceneEnd()
    {
        LoadScene("L1");
    }
}
