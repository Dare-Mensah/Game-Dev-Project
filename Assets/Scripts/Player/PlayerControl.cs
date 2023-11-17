using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody rB;
    public float moveSpeed, jumpForce;

    private Vector2 moveInput;


    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGround;

    public SpriteRenderer sR;

    private bool movingBackwards;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Vertical");
        moveInput.y = Input.GetAxis("Horizontal");

        moveInput.Normalize();

        rB.velocity = new Vector3(moveInput.x * moveSpeed, rB.velocity.y, moveInput.y * moveSpeed);

        RaycastHit hit;

        if(Physics.Raycast(groundPoint.position,Vector3.down, out hit, .3f, whatIsGround))
        {
            isGround = true;

        } else
        {
            isGround = false;
        }

        if(Input.GetButtonDown("Jump") && isGround)
        {
            rB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        if(!sR.flipX && moveInput.y < 0)
        {
            sR.flipX = true;

        } else if(sR.flipX && moveInput.y > 0)
        {
            sR.flipX = false;
        }

        if(!movingBackwards && moveInput.x > 0)
        {
            movingBackwards = true;

        } else if(movingBackwards && moveInput.x < 0)
        {
            movingBackwards = false;
        }
        
    }
}
 