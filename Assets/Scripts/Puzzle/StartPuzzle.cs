using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    public GameObject puzzleCam;
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
        puzzleCam.SetActive(true);
        StartCoroutine(WaitForPlayer());
    }


    IEnumerator WaitForPlayer()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(2);
    }
}
