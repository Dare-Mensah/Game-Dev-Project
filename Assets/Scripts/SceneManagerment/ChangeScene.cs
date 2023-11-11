using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelName; //teaks level name in script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ClickButton()
    {
        SceneManager.LoadScene(levelName); //loads the scene according to the level name string
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    { //for tutorial level
        if(other.gameObject.tag =="Player") 
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
