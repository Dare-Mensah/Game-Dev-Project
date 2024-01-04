using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class PlayerController : MonoBehaviour
{
    public float moveForce;     // Force applied when we move left or right.
    public Rigidbody rig;       // A referene to our Rigidbody component.
    // Called 60 times a second.
    // Similar to the Update function, but used for physics calculations.
    void FixedUpdate()
    { //method is called in fixed intervals for more effective process handlings
        // Get the horizontal input.
        // 0 = nothing
        // 1 = right
        // -1 = left
        float xInput = Input.GetAxis("Horizontal");//allows for input to be detected from user action i.e how the player intends to move across horizontal axis
        // Add force based on our input.
        rig.AddForce(Vector3.right * xInput * moveForce);
    }
}
