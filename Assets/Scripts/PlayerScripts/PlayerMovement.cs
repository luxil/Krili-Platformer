using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //move the player or not
    public bool bMovePlayer, bGrounded, bJump;
    //running speed of the player
    public float fRunningSpeed;
    public Transform TGroundCheck;
    public float fJumpForce = 10f;

    private Rigidbody rbPlayer;

    // Use this for initialization
    void Start () {
        bMovePlayer = true;
        fRunningSpeed = 0.03f;

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
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            bGrounded = true;
        }
    }
}
