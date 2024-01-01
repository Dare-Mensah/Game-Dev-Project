using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVid;

    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        myVid.loopPointReached += VideoFinish; //checking if the video is finsined
    }

    void VideoFinish (VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneName);
    }
}
