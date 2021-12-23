using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public bool isActive = false;

    public void timelineOn() 
    {
        isActive = true;
    }

    public void timelineOff()
    {
        isActive = false;
    }
}
