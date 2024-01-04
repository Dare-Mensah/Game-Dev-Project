using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine; //importing unity engine that will allow for unity based functions and features to be deployed successfully
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{   // the videoscript class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features

    [SerializeField]
    VideoPlayer myVid;

    public string sceneName;//public reference to the sceneName variable that defines the titled name of scenes
    // Start is called before the first frame update
    void Start() 
    { //start method called and defined to allow for checks to run pertaining whether video has completed
        myVid.loopPointReached += VideoFinish; //checking if the video is finsined
    }

    void VideoFinish (VideoPlayer vp)
    { //method videofinish is defined and called upon
        Initiate.Fade(sceneName, Color.black, 1); //loads the scene according to the level name string
    }
}
