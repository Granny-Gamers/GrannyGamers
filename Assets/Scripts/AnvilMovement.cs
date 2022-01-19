using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilMovement : MonoBehaviour
{
    // Field for passing the turn system.
    public TurnSystem turnSystem;

    // Internal turn counter to check if the turn has changed or not.
    private int _turn = 0;

    // Indicates if the anvil is a copy or the original.
    public bool isCopy = false;

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveHandler();
    }

    // Checks if a turn has occured and handles the movement logic as needed.
    private void MoveHandler()
    {
        // Anvil should only move if it is a copy and a turn is occuring.
        if (isCopy && _turn < turnSystem.turnCount)
        {
            transform.position += new Vector3(0, -1, 0); 
            _turn = turnSystem.turnCount;
        }
    }
    
    // Detects when the anvil colides with another object.
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground collision
        if (collision.gameObject.name == "Ground")
            Destroy(gameObject);
    }

    // Helper function that toggles if the object is active or not.
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}
