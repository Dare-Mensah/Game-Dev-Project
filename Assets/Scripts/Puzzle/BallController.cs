using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine for unity based work to  be conducted effectively

public class BallController : MonoBehaviour
{
    public float Speed; //dictates the speed of the ball
    //move of Horizontal
    public float moveHorizontal;
    //move of vertical
    public float moveVertical;

    Rigidbody rB; //this is private reference to the rigidbody component that controls the players movement
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>(); //initialising the rigidbody with the rigidbody component that is attached to the same game obj
    }

    void FixedUpdate()
    { //is called at fixed durations that enables for more effective handling of physics updates
        moveHorizontal = Input.GetAxis("Horizontal"); //MOVES PLAYER IN HORIZONTAL AND VERTICAL AXIS
        moveVertical = Input.GetAxis("Vertical"); //moving player on the vertical axis

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //this will create a new vector3 based upon the detected horizontal and vertical input that results in no movement on the y axis

        rB.AddForce(movement * Speed); // ADDS FORCE IN THE DIRECTION OF MOVEMENT TO RGIDBODY

        //print(moveHorizontal);
        //print(moveVertical);
    }

    // Update is called once per frame and is an example of a unity specific method utilised
    void Update()
    {
        
    }
}
