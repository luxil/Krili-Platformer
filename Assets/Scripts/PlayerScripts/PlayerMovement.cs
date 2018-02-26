using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool bMovePlayer, bGrounded; // move the player or not
    public Transform TGroundCheck;  // to check if the player is touching the ground
    public float fJumpForce = 1000f;    
    const float cfRunningSpeed = 8.5f;  // running speed of the player

    public bool bFalling = false;   // indicates if the player is falling or not   
    private float fLastY;   // last grounded height
    //private CharacterController ccCharacter;

    private Rigidbody rbPlayer;


    void Start () {
        bMovePlayer = true;
        bGrounded = true;

        //ccCharacter = GetComponent<CharacterController>();
        fLastY = transform.position.y;

        rbPlayer = GetComponent<Rigidbody>();
    }
	

	void FixedUpdate () {

        //move the player along the x-Axis
        if (bMovePlayer)
        {
            float fTranslation = Time.fixedDeltaTime * cfRunningSpeed;
            transform.Translate(fTranslation, 0, 0);
        }

        /**********************************************
        *   PC Controls (mostly for testing purpose)
        **********************************************/
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

        /// <summary>
        /// The following code bit was done only for testing purposes and is therefore a comment.
        /// It is still part of the code as we frequently reuse it to test some level designs. 
        /// </summary>

/*      //player can run faster
        if (Input.GetKeyDown("right"))
        {
           fRunningSpeed = 0.9f;
        }

        //slow player down
        if (Input.GetKeyUp("right"))
        {
            fRunningSpeed = cfRunningSpeed;
        }
*/

        // if character not grounded...
        if (!bGrounded)
        {
            // assume it's falling 
            bFalling = true;
        }

        // if character grounded... 
        else
        {
            // but was falling last update... 
            if (bFalling)
            { 
                // calculate the fall height... 
                var hFall = fLastY - transform.position.y;
                
                // then check the damage/death 
                if (hFall > 8)
                {
                    // player is dead 
                    CommonGameobjects.Instance.goMenuCanvas.SetActive(true);
                    CommonGameobjects.Instance.goGameOverPanel.SetActive(true);
                }
            }
            // update lastY when character grounded 
            fLastY = transform.position.y; 
        }
        
    }

    // if the player jumps (and therefore doesn't collide with the floor anymore), change bGrounded accordingly
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            bGrounded = false;
        }
    }

    // if the player is collding with the floor, set bGrounded accordingly
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            bGrounded = true;
        }
    }

    public void Jump()
    {
        //only allow jump if player is on the ground
        if (bGrounded)
        {
            if (bMovePlayer)
                rbPlayer.AddForce((Vector3.up * 1.15f + Vector3.right * 0.05f) * fJumpForce);
            else
                rbPlayer.AddForce((Vector3.up * 1.2f + Vector3.right * 0.4f) * fJumpForce);
           
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

    //player should stop/run
    public void ToggleMovement()
    {
        bMovePlayer = !bMovePlayer;
    }
}
