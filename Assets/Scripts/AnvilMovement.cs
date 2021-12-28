using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilMovement : MonoBehaviour
{
    public TurnSystem turnSystem;

    public bool isCopy = false;

    public int _turn;

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        if (isCopy && _turn < turnSystem.turnCount)
        {
            transform.position += new Vector3(0, -1, 0); 
            _turn = turnSystem.turnCount;
        }
    }
}
