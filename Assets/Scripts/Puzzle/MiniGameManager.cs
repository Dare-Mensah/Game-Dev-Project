using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public AudioSource winSound;
    public AudioSource loseSound;

    public GameObject winText;
    public GameObject loseText;

    // Update is called once per frame
    void Update()
    {
        if(winText.activeInHierarchy == true)
        {
            winSound.Play();
        }
        else if (loseText.activeInHierarchy == true)
        {
            loseSound.Play();
        }
    }
}
