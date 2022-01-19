using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    // Passable field for indicating if there is a timeline occuring or not.
    public bool isActive = false;

    // Sets the timeline as on / timeline is occuring.
    public void timelineOn() 
    {
        isActive = true;
    }

    // Sets the timeline as off / timeline is not occuring.
    public void timelineOff()
    {
        isActive = false;
    }
}
