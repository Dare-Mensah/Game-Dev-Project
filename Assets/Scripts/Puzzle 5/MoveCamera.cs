using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class MoveCamera : MonoBehaviour
{  // the movecamera class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public Transform cameraPosition; //declaring the camera position of which is modified within unity to follow the game object desired

    private void Update()
    { //defining private method update that is called once a frame
        transform.position = cameraPosition.position; //sets the position of the current object to the position of the camera object
    }
}
