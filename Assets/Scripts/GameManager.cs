using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Movement");
        FindObjectOfType<AudioManager>().Play("Game Over");
        FindObjectOfType<SceneHandler>().L1CutsceneEnd();
    }

    public void Win()
    {
        Debug.Log("You win!");
    }
}
