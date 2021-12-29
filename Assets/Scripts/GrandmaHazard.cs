using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaHazard : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Anvil(Clone)")
            FindObjectOfType<GameManager>().GameOver();
    }
}
