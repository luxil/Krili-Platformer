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

    public bool bFalling = false; // tells when the player is falling 
    private float fLastY; // last grounded height 
    private CharacterController ccCharacter;

    private Rigidbody rbPlayer;

    // Use this for initialization
    void Start () {
        bMovePlayer = true;
        fRunningSpeed = 0.03f;

        ccCharacter = GetComponent<CharacterController>();
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
        if (Input.GetKeyDown(KeyCode.J))
        {
            bMovePlayer = !bMovePlayer;
        }

        //player can run faster
        if (Input.GetKeyDown(KeyCode.H))
        {
            fRunningSpeed = 0.07f;
        }
        //slow player down
        if (Input.GetKeyUp(KeyCode.H))
        {
            fRunningSpeed = 0.03f;
        }

        if (Input.GetButtonDown("Jump") && bGrounded)
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
            rbPlayer.AddForce(Vector3.up * fJumpForce);
            bJump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        
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
}
