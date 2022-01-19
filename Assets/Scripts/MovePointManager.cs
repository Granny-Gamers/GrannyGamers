using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointManager : MonoBehaviour
{
    // Passable field for targeting the timeline manager.
    public TimelineManager timelineManager;

    // Passable field for targeting the move point.
    public Transform movePoint;

    // Update is called once per frame.
    void Update()
    {
        // If there is no timeline occuring, then the move point should not move with the grandma.
        if (timelineManager.isActive == false && movePoint.parent != null)
            movePoint.parent = null;

        // If there is a timeline occuring, then the move point should move with the grandma. 
        else if (timelineManager.isActive == true && movePoint.parent == null)
            movePoint.parent = FindObjectOfType<GrandmaMovement>().transform;
    }
}
