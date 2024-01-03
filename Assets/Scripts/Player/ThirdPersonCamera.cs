using System.Collections; // use of statement ensures the system.collection is imported to be used for collections like arrays
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{// thirdpersoncamera class that inherits from the monobehaviour class which thus enables for it to be assigned to the gameobjects and make use of unity features


    [Header("Refernces")]
    //Refernces to the in game transform objects.
    public Transform Orientation; //this references an orientation transform that controls the camera orientation
    public Transform Player;// public var to reference a players transformation
    public Transform PlayerObject; // this is a public transform that references the playerobject
    public Rigidbody rB; //references the rigidbody assigned to playable character

    public float rotatioSpeed; //float variable dictates the speed of camera rotation

    public Transform focusLookAt; // transform is utilised to focus camera style

    public GameObject BasicCam; //references the basic camera game object
    //public GameObject FocusCam;
    //public GameObject PuzzleCam;

    public CamraPosition currentstyle;//variable tracks the current camera dynamic

    public enum CamraPosition
    { //this is utilised to define a variety of different camera styles
        Basic, 
        Focus,
        Puzzle,
    }


    // Start is called before the first frame update
    void Start()
    {
        // making the cursor invisible and locked to center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCamPos(CamraPosition.Basic);
        //NOT NECESSARY
       // if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCamPos(CamraPosition.Focus);
        //if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCamPos(CamraPosition.Puzzle);



        //finding out the rotation oritnation
        Vector3 viewDirection = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);//calculating the direction of camera in relation to that of the player
        Orientation.forward = viewDirection.normalized; //this sets the orientation to be a forward directionin comparison to view direction

        //Rotating the player object
        if(currentstyle == CamraPosition.Basic || currentstyle == CamraPosition.Puzzle) // normal basic camera angle
        {
            float horizontalInput = Input.GetAxis("Horizontal"); //code obtains the horizontal input
            float verticalInput = Input.GetAxis("Vertical"); //code obtains the vertical input
            Vector3 inputDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

            if (inputDirection != Vector3.zero) //if condition checks to see if any input is detected at which point it will redirect player direction to the input direction
                PlayerObject.forward = Vector3.Slerp(PlayerObject.forward, inputDirection.normalized, Time.deltaTime * rotatioSpeed);
        }
        
        else if(currentstyle == CamraPosition.Focus)
        {
            Vector3 dirToFocusLookAt = focusLookAt.position - new Vector3(transform.position.x, focusLookAt.position.y, transform.position.z);  
            Orientation.forward = dirToFocusLookAt.normalized; // focusing camera on the focus empty game object to provide a new camera angle 

            PlayerObject.forward = dirToFocusLookAt.normalized; //this sets the players forward direction to be that of the the direction of the focus look at Transform
        }
    }

    private void SwitchCamPos(CamraPosition newPosition) //IF WE WANT TO CHANGE THE POSITION OF THE CAMERA WITH THE PLAYER IN FURTURE ITERATIONS
    {
        //NOT NECESSARY
        BasicCam.SetActive(true);
        //FocusCam.SetActive(false);
        //PuzzleCam.SetActive(false);

        if (newPosition == CamraPosition.Basic) BasicCam.SetActive(true);
        //if (newPosition == CamraPosition.Focus) FocusCam.SetActive(true);
        //if (newPosition == CamraPosition.Puzzle) PuzzleCam.SetActive(true);

        currentstyle = newPosition; //updating the current style to be representative of the nee position as shown through use of intialisation

    }
}
