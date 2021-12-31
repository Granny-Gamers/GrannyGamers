using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Anvil(Clone)")
            FindObjectOfType<GameManager>().GameOver();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Bench")
            FindObjectOfType<GameManager>().Win();
    }
}
