using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public GameObject LevelComplete;

    public PlayableDirector l1Post;

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Movement");
        FindObjectOfType<AudioManager>().Play("Game Over");
        FindObjectOfType<SceneHandler>().L1CutsceneEnd();
    }

    public void Win()
    {
        l1Post.Play();
    }

    public void L1Complete()
    {
        LevelComplete.SetActive(true);
    }
}
