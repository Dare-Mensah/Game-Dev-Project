using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   // the changescene class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    public string levelName; //public reference made to the level name which holds the name of levels

    public void ClickButton()
    { //public method is called to enable for correct action to be executed upon actioned clickbutton
        Initiate.Fade(levelName, Color.black, 1); //loads the scene according to the level name string
    }

    public void Quit()
    {
        Application.Quit(); //use of .Quit() method ensures for effective process handling when the application is quit
    }

    private void OnTriggerEnter(Collider other)
    { //utilised for tutorial level....also is private method defined for when players enter the trigger collider
        if(other.gameObject.tag =="Player") 
        { //condition based if statement is a check to see if game object is tagged as "player"
            Initiate.Fade(levelName, Color.black, 1); //loads the scene according to the level name string
        }
    }
}
