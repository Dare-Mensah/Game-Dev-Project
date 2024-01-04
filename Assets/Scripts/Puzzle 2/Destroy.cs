using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using TMPro;
using UnityEngine.UI; //unity engine UI imported to allow for qualitative features to be deployed effectively
public class Destroy : MonoBehaviour
{ // the Destroy class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Cube(Clone)") //CHECKS IF THE GAMEOBJECT IS CUBE(CLONE) AND REMOVES ALL THE CUBES GENERATED FROM SPAWNER
        {
            Destroy(gameObject, 5); // game object is destroyed 5 seconds after code execution as made possible through the use of the Destroy () that we have parameterised
        }
    }
    private void OnCollisionEnter(Collision collision) { //method called should player enter the collision collider
        if(collision.gameObject.tag == "Ball") //condiiton based check to see whether the game object is tagged as being "Ball"
        {
            Destroy(gameObject); //DESTROYS THE CUBE IF IT COLLDIES WITH THE BALL
           
        }


        

    }
}
