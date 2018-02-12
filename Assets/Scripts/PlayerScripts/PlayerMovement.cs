using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //move the player or not
    public bool bMovePlayer, bGrounded;
    //running speed of the player
    public float fRunningSpeed;
    public Transform TGroundCheck;
    public float fJumpForce = 1000f;
    const float cfRunningSpeed = 0.15f;

    // tells when the player is falling 
    public bool bFalling = false;
    // last grounded height 
    private float fLastY; 
    //private CharacterController ccCharacter;

    private Rigidbody rbPlayer;

    // Use this for initialization
    void Start () {
        bMovePlayer = true;
        bGrounded = true;
        fRunningSpeed = cfRunningSpeed;

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
        
        ///pc controls
        if (Input.GetKeyDown("left"))
        {
            ToggleMovement();
        }
        
        if (Input.GetKeyDown("down"))
        {
            Crouch();
        }

        if (Input.GetKeyUp("down"))
        {
            CancelCrouch();
        }

        if (Input.GetKeyDown("up") && bGrounded)
        {
            Jump();
        }

        ///for testing purposes
        ////player can run faster
        //if (Input.GetKeyDown("right"))
        //{
        //    fRunningSpeed = 0.9f;
        //}

        ////slow player down
        //if (Input.GetKeyUp("right"))
        //{
        //    fRunningSpeed = cfRunningSpeed;
        //}

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

    public void Jump()
    {
        if (bGrounded)
        {
            if (bMovePlayer)
                rbPlayer.AddForce((Vector3.up * 1.15f + Vector3.right * 0.05f) * fJumpForce);
            else
                rbPlayer.AddForce((Vector3.up * 1.2f + Vector3.right * 0.25f) * fJumpForce);
           
        }
    }

    //player should crouch
    public void Crouch()
    {
        transform.localScale -= new Vector3(0, 0.6f, 0);
        transform.position -= new Vector3(0, 0.6f, 0);
    }

    //player should stop crouching
    public void CancelCrouch()
    {
        transform.localScale += new Vector3(0, 0.6f, 0);
        transform.position += new Vector3(0, 0.6f, 0);
    }

    //player should stop or run
    public void ToggleMovement()
    {
        bMovePlayer = !bMovePlayer;
    }
}
