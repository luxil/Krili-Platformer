﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour {

    public GameObject goPlayer;

    //Private variable to store the offset distance between the player and camera
    private Vector3 offset;
    private float offsetY;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - goPlayer.transform.position;
        offsetY = goPlayer.transform.position.y;
        //offset = new Vector3(offset.x, goPlayer.transform.position.y, offset.z);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = goPlayer.transform.position + offset;
        transform.position = new Vector3(goPlayer.transform.position.x, offsetY, goPlayer.transform.position.z) + offset;
    }
}
