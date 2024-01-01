using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator animator; //player animation

    public AudioSource jumpSound;
    public AudioSource moveSound;

    [Header("Movement Refernces")]
    public float movespeed;

    public float groundedDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space; //spacebar for jump input
    

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation; // current player orientation

    [Header("Sprite")]
    public SpriteRenderer sR;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;

    Rigidbody rB;

    


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rB = GetComponent<Rigidbody>();
        rB.freezeRotation = true;

        resetJump();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //checking if user in touchning the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        MyInput();
        SpeedControl();

        if (grounded)
            rB.drag = groundedDrag;
        else
            rB.drag = 0;

        // Set the "isMoving" parameter in the animator based on player's movement


        if (horizontalInput != 0f || verticalInput != 0f)
        {
            animator.SetBool("isMoving", true);
            
        }
        else
        {
            animator.SetBool("isMoving", false);
        }


        if (!sR.flipX && horizontalInput < 0) //flips the sprite depening on where the player is facing
        {
            sR.flipX = true;

        }
        else if (sR.flipX && horizontalInput > 0)
        {
            sR.flipX = false;
        }


    }

    public void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //W and S
        verticalInput = Input.GetAxisRaw("Vertical"); // A and D
        

        if (Input.GetKey(jumpKey) && readyToJump && grounded) // if ready to jump is true and the player is grounded
        {
            readyToJump = false;

            Jump();

            jumpSound.Play();

            Invoke(nameof(resetJump), jumpCooldown);

        }
    }

    private void MovePlayer()
    {
        // move Direction
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // adding force in the direction the user is looking in
        if (grounded)
        {
            rB.AddForce(moveDir.normalized * movespeed * 10f, ForceMode.Force);

            // Check if the player is moving and play the moveSound
            if ((horizontalInput != 0f || verticalInput != 0f) && !moveSound.isPlaying)
            {
                moveSound.Play();
            }
            else if (horizontalInput == 0f && verticalInput == 0f)
            {
                // Stop the moveSound when the player is not moving
                moveSound.Stop();
            }
        }
        else if (!grounded)
        {
            rB.AddForce(moveDir.normalized * movespeed * 10f * airMultiplier, ForceMode.Force);

            // Stop the moveSound when the player is not grounded
            moveSound.Stop();
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rB.velocity.x, 0f, rB.velocity.z);

        if(flatVel.magnitude > movespeed) //limiting your velocity
        {
            Vector3 limitedVel = flatVel.normalized * movespeed;
            rB.velocity = new Vector3(limitedVel.x, rB.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rB.velocity = new Vector3(rB.velocity.x, 0f, rB.velocity.z);
        rB.AddForce(transform.up * jumpForce, ForceMode.Impulse); //addding force to rb to jump with transform.up
    }

    private void resetJump()
    {
        readyToJump = true;
    }
}
