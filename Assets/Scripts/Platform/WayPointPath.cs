using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetWayPoint(int wayPointIndex)
    {
        return transform.GetChild(wayPointIndex);//returns the transform of the way point idex
    }

    public int getNextWayPointIndex(int currentWayPointIndex)
    {
        int nextWayPointIndex = currentWayPointIndex + 1;

        if (nextWayPointIndex == transform.childCount)
        {
            nextWayPointIndex = 0; //sets the index to zero to start from the begining.
        }

        return nextWayPointIndex;
    }

}
