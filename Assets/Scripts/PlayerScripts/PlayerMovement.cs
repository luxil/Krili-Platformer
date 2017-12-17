using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //move the player or not
    public bool bMovePlayer, bGrounded, bJump;
    //running speed of the player
    public float fRunningSpeed;
    public Transform TGroundCheck;
    public float fJumpForce = 500f;

    // tells when the player is falling 
    public bool bFalling = false;
    // last grounded height 
    private float fLastY; 
    //private CharacterController ccCharacter;

    private Rigidbody rbPlayer;

    // Use this for initialization
    void Start () {
        bMovePlayer = true;
        fRunningSpeed = 0.2f;

        //ccCharacter = GetComponent<CharacterController>();
        fLastY = transform.position.y;

        rbPlayer = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        //bGrounded = Physics.Linecast(transform.position, TGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //move the player along the x-Axis
        if (bMovePlayer)
        {
            transform.Translate(fRunningSpeed, 0, 0);
        }

        //player should stop or run
        if (Input.GetKeyDown("left"))
        {
            bMovePlayer = !bMovePlayer;
        }

        //player can run faster
        if (Input.GetKeyDown("right"))
        {
            fRunningSpeed = 0.9f;
        }
        //slow player down
        if (Input.GetKeyUp("right"))
        {
            fRunningSpeed = 0.2f;
        }

        //player should duck
        if (Input.GetKeyDown("down"))
        {
            transform.localScale -= new Vector3(0, 0.6f, 0);
            transform.position -= new Vector3(0, 0.6f, 0);
        }

        //player should stop duck
        if (Input.GetKeyUp("down"))
        {
            transform.localScale += new Vector3(0, 0.6f, 0);
            transform.position += new Vector3(0, 0.6f, 0);
        }

        if (Input.GetKeyDown("up") && bGrounded)
        {
            bJump = true;
        }

        if (!bGrounded)
        {
            bFalling = true;
        }
        else
        {
            if (bFalling)
            { // but was falling last update... 
                var hFall = fLastY - transform.position.y;
                // calculate the fall height... 
                if (hFall > 8)
                { // then check the damage/death // player is dead 
                    Debug.Log("PLAYER DEAD");
                }
            }
            fLastY = transform.position.y; // update lastY when character grounded 
        }
        
    }

    void FixedUpdate()
    {
        if (bJump)
        {
            rbPlayer.AddForce((Vector3.up + Vector3.right*0.2f) * fJumpForce);
            bJump = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            bGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            bGrounded = true;
        }
    }

    public void jump()
    {
        if (bGrounded)
        {
            bJump = true;
        }
    }

    public void crouch()
    {
        Debug.Log("crouch works");
        transform.localScale -= new Vector3(0, 0.6f, 0);
        transform.position -= new Vector3(0, 0.6f, 0);
    }

    public void cancelCrouch()
    {
        transform.localScale += new Vector3(0, 0.6f, 0);
        transform.position += new Vector3(0, 0.6f, 0);
    }

    public void toggleMovement()
    {
        bMovePlayer = !bMovePlayer;
    }
}
