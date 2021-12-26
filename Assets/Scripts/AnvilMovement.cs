using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilMovement : MonoBehaviour
{
    public TurnSystem turnSystem;

    public Transform movePoint;
    public float moveSpeed;

    private int _turn = 0;

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        if (_turn < turnSystem.turnCount)
        {
            movePoint.parent = null;
            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                _turn++;
                AdvanceMovePoint(0, -1);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed);
    }

    // Changes the move point's position based on horizontalDist and verticalDist.
    private void AdvanceMovePoint(float horizontalDist, float verticalDist)
    {
        movePoint.position += new Vector3(horizontalDist, verticalDist, 0);
    }
}
