using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    // Passable field for win graphic.
    public GameObject levelComplete;

    // Passable field for lose graphic.
    public GameObject gameOver;

    // Passable field for move and turn display.
    public GameObject debugCanvas;

    // Passable field for the post-level 1 cutscene.
    public PlayableDirector l1Post;

    // Handles the lose game state of the first level.
    public IEnumerator Lose()
    {
        FindObjectOfType<AudioManager>().StopPlaying("Movement");
        FindObjectOfType<AudioManager>().Play("Game Over");

        debugCanvas.SetActive(false);
        gameOver.SetActive(true);
        yield return new WaitForSeconds(3f);
        FindObjectOfType<SceneHandler>().L1CutsceneEnd();
    }

    // Handles the win game state of the first level.
    public void Win()
    {
        l1Post.Play();
    }

    // Displays the win graphic for level 1.
    public void L1Complete()
    {
        levelComplete.SetActive(true);
    }
}
