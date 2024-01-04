using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully

public class Spawner : MonoBehaviour
{  // the spawner class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    // Start is called before the first frame update
    //time gap in seconds for how often a cube is spawned
    public float _delay = 0.9f;
    //represents the cube to be spawned
    public GameObject _cube; //public reference to the game object _cube which players collide with
    //present message if you are winning
    public GameObject WinText; //public reference to the win text game object that displays win text

    public GameObject timeUp;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", _delay, _delay); //this will repeat the instantiation process

    }

    void Spawn()
    { //spawn method is called to allow for adequate instantiation of a newly generated cube
        Instantiate(_cube, transform.position, Quaternion.identity); //INSTATIATES A NEW CUBE 
    }

    // Update is called once per frame
    void Update()
    {

        if(WinText.activeInHierarchy == true || timeUp.activeInHierarchy == true)
        { //IF PLAYER WINS THEN STOPS SPAWNING CUBES
            CancelInvoke(); //this is called to stop all impending invokes that monobehaviour class is subjected to
        }
    }
}
