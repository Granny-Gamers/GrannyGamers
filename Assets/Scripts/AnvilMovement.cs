using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilMovement : MonoBehaviour
{
    public TurnSystem turnSystem;

    public bool isCopy = false;

    private int _turn = 0;

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
            _turn++;
        }
    }
}
