
/**********************************************
*   This script is for handling the camera movement with the player. The camera should not move up and down with the player.
**********************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour {

    public GameObject goPlayer;

    //Private variable to store the offset distance between the player and camera
    private Vector3 v3Offset;
    private float fOffsetY;


    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        v3Offset = transform.position - goPlayer.transform.position;
        fOffsetY = goPlayer.transform.position.y;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(goPlayer.transform.position.x, fOffsetY, goPlayer.transform.position.z) + v3Offset;
    }
}
