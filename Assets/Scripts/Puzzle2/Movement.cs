using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    int counter=0;
    //speed of movement
    public int speed; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal")/speed,0,0); //MOVES BALL ON THE HORIZONTAL AXIS
    }
    private void OnCollisionEnter(Collision collision) {
        //increase counter after collision
        counter=counter+1;
    }
}
