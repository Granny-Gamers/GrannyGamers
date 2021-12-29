using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaManager : MonoBehaviour
{
    public Transform movePoint;

    public void ParentOff()
    {
        movePoint.parent = null;
    }
}
