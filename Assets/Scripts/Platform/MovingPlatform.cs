using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WayPointPath _wayPointPath;

    [SerializeField]
    private float speed;

    private int targetWayPointIndex;

    private Transform previousWayPoint;
    private Transform targetWayPoint;

    private float timeToWayPoint;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercent = elapsedTime / timeToWayPoint;
        elapsedPercent = Mathf.SmoothStep(0, 1, elapsedPercent);
        transform.position = Vector3.Lerp(previousWayPoint.position, targetWayPoint.position, elapsedPercent); //Moving the platform with lerp to make it smoother
        transform.rotation = Quaternion.Lerp(previousWayPoint.rotation, targetWayPoint.rotation, elapsedPercent); //rotating the platform as it moves 

        if (elapsedPercent >= 1)
        {
            TargetNextWayPoint();
        }
    }

    private void TargetNextWayPoint()
    {
        previousWayPoint = _wayPointPath.GetWayPoint(targetWayPointIndex);
        targetWayPointIndex = _wayPointPath.getNextWayPointIndex(targetWayPointIndex);
        targetWayPoint = _wayPointPath.GetWayPoint(targetWayPointIndex);
        //The target way point is the next watpoint form way point index.

        elapsedTime = 0;

        float distanceToWayPoint = Vector3.Distance(previousWayPoint.position, targetWayPoint.position);
        timeToWayPoint = distanceToWayPoint / speed; //the time to get there is dependent on the distance and speed

    }


}
