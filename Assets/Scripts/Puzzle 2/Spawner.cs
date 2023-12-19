using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //time gap in seconds for how often a cube is spawned
    public float _delay = 0.9f;
    //represents the cube to be spawned
    public GameObject _cube;
    //present message if you are winning
    public GameObject WinText;

    public GameObject timeUp;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", _delay, _delay); //REPEATS THE INSTANTIATE

    }

    void Spawn()
    {
        Instantiate(_cube, transform.position, Quaternion.identity); //INSTATIATES A NEW CUBE 
    }

    // Update is called once per frame
    void Update()
    {

        if(WinText.activeInHierarchy == true || timeUp.activeInHierarchy == true)
        { //IF PLAYER WINS THEN STOPS SPAWNING CUBES
            CancelInvoke(); 
        }
    }
}
