using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class Movement : MonoBehaviour
{ // the Destroy class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    // Start is called before the first frame update
    int counter=0; //declaring and intialising counter variable to start at a count of 0
    public int speed; //declaring the speed variable as per its integer datatype to allow for suitable data to be parsed
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")/speed,0,0); //MOVES BALL ON THE HORIZONTAL AXIS
    }
    private void OnCollisionEnter(Collision collision) { //method is called should the player enter the collision collider at which point proceeding code is executed upon
        counter=counter+1; //counter is incremented by 1 as per the no of collisions the player initiates
    }
}
