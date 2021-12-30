using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Anvil(Clone)")
            FindObjectOfType<GameManager>().GameOver();

        else if (collision.gameObject.name == "Bench")
            FindObjectOfType<GameManager>().Win();
    }
}
