using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointManager : MonoBehaviour
{
    public TimelineManager timelineManager;
    public Transform movePoint;

    // Update is called once per frame
    void Update()
    {
        if (timelineManager.isActive == false && movePoint.parent != null)
            movePoint.parent = null;

        else if (timelineManager.isActive == true && movePoint.parent == null)
            movePoint.parent = FindObjectOfType<GrandmaMovement>().transform;
    }
}
