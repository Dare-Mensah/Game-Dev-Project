using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unityengine to allow for unity based work to be conducted


public class MovingPlatform : MonoBehaviour
{ // playerlookat class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    [SerializeField]
    private WayPointPath _wayPointPath; //serialized private field references path the platform will follow

    [SerializeField]
    private float speed; //serialised private field wil set the speed of the platform movement

    private int targetWayPointIndex; // private int variable tracks the current target waypoint index within the path

    private Transform previousWayPoint; //private transform is used to keep a track of the last way point at which platform was at
    private Transform targetWayPoint; //private transform is used to ascertain the current waypoint that the platform is moving toward

    private float timeToWayPoint; // private float calculates time taken to reach next waypoint
    private float elapsedTime; //private float tracks how much time has passed since platform moved to the next waypoint

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWayPoint(); //calls method to target the next way point initialising the platforms movement
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime; //increases the passes time by the amount of time elapsed since last frame

        float elapsedPercent = elapsedTime / timeToWayPoint; //calculating percentage of joruney completed based on elapsed time toal and time taken to reach the way point
        elapsedPercent = Mathf.SmoothStep(0, 1, elapsedPercent); //appends a smoothening function that renders movement to become more natural in nature
        transform.position = Vector3.Lerp(previousWayPoint.position, targetWayPoint.position, elapsedPercent); //Moving the platform with lerp to make it smoother
        transform.rotation = Quaternion.Lerp(previousWayPoint.rotation, targetWayPoint.rotation, elapsedPercent); //rotating the platform as it moves 

        if (elapsedPercent >= 1)
        { //checks to see if the platform has reached/passed the target way point
            TargetNextWayPoint(); // calls the method to thus target the next way point to continue movement
        }
    }

    private void TargetNextWayPoint()
    { //private method is used for targeting the next way point within the path
        previousWayPoint = _wayPointPath.GetWayPoint(targetWayPointIndex); // this sets the previous way point to the current target way point
        targetWayPointIndex = _wayPointPath.getNextWayPointIndex(targetWayPointIndex); //calculates the index of the next waypoint and updates the target waypoint index
        targetWayPoint = _wayPointPath.GetWayPoint(targetWayPointIndex);
        //setting the target way point to the new calculated way point.

        elapsedTime = 0; //resets the elapsed time as the platform begins to move toward a new waypoint

        float distanceToWayPoint = Vector3.Distance(previousWayPoint.position, targetWayPoint.position);
        timeToWayPoint = distanceToWayPoint / speed; //the time to get there is dependent on the distance and speed

    }


}
