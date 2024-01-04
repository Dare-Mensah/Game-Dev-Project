using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class Coin : MonoBehaviour
{ // the coin class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    { //method is called if the player enters the collision collider and thus proceeding code is actioned upon
        if (collision.gameObject.tag == "Ball")
        { //if statement is a conditional check to see whether the game object is tagged as being "ball"
            Destroy(gameObject); //DESTROYS THE CUBE IF IT COLLDIES WITH THE BALL

        }
    }
}
