using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Destroy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Cube(Clone)")
        {
            Destroy(gameObject, 5);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
           
        }


        

    }
}
