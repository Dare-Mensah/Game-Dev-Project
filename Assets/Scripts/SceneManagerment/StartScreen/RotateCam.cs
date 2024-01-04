using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class RotateCam : MonoBehaviour
{  // the rotatecam class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame and is defined below
    void Update()
    {
        transform.Rotate(new Vector3(0f, 20f, 0f) * Time.deltaTime); //rotates camera on y axis that is made possible via the use of the .Rotate() function
    }
}
