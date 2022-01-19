using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaManager : MonoBehaviour
{
    // Passable field for targeting the move point.
    public Transform movePoint;

    // Makes the movePoint's parent null.
    public void ParentOff()
    {
        movePoint.parent = null;
    }
}
