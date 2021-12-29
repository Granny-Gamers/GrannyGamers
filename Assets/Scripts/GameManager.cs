using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public PlayableDirector l1Post;

    public void GameOver()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Movement");
        FindObjectOfType<AudioManager>().Play("Game Over");
        FindObjectOfType<SceneHandler>().L1CutsceneEnd();
    }

    public void Win()
    {
        Debug.Log("Win");
        l1Post.Play();
    }
}
