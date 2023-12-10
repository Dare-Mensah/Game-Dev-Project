using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //checks if the player has interacted with the coin
        {
            Destroy(gameObject); //destroys game object
        }
    }
}
