using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCollision : MonoBehaviour
{
    // Detects when the grandma collides with another object.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hazard collision with anvil.
        if (collision.gameObject.name == "Anvil(Clone)")
            StartCoroutine(FindObjectOfType<GameManager>().Lose());
    }

    // Detects when the grandma goes thru a trigger.
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Win condition trigger.
        if (collider.gameObject.name == "Bench")
            FindObjectOfType<GameManager>().Win();
    }
}
