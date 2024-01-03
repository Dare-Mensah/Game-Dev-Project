using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted

public class WayPointPath : MonoBehaviour
{// playerlookat class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetWayPoint(int wayPointIndex) //public method for attaining the waypoints transform which is determined based on its index
    {
        return transform.GetChild(wayPointIndex);//returns the transform of the way point index
    }

    public int getNextWayPointIndex(int currentWayPointIndex)
    { // public method is used to calculate the index of the proceeding way point
        int nextWayPointIndex = currentWayPointIndex + 1; // increases the current waypoint index to obtain the next waypoint index

        if (nextWayPointIndex == transform.childCount)
        { //if condition checks to see if the next way point index equals the no of children 
            nextWayPointIndex = 0; //sets the index to zero to start from the begining.
        }

        return nextWayPointIndex; //return statement used in order to return the ascertained next way point index
    }

}
