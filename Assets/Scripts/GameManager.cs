using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public GameObject levelComplete;

    public GameObject gameOver;

    public GameObject debugCanvas;

    public PlayableDirector l1Post;

    public IEnumerator Lose()
    {
        debugCanvas.SetActive(false);
        FindObjectOfType<AudioManager>().StopPlaying("Movement");
        FindObjectOfType<AudioManager>().Play("Game Over");
        gameOver.SetActive(true);
        yield return new WaitForSeconds(3f);
        FindObjectOfType<SceneHandler>().L1CutsceneEnd();
    }

    public void Win()
    {
        l1Post.Play();
    }

    public void L1Complete()
    {
        levelComplete.SetActive(true);
    }
}
