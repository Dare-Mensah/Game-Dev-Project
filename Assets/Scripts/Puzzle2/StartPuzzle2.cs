using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle2 : MonoBehaviour
{

    public GameObject puzzleCam;
    public GameObject playerCam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

            puzzleCam.SetActive(true);
            player.SetActive(false);
            playerCam.SetActive(false);
        }
    }
}
