﻿/**********************************************
*   script to handle moving platforms that only move when the player is on them
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformOnColScript : MonoBehaviour {

    public float speed = 1; // platform speed (public so it's easily changeable in the editor)
    private int direction = 1;  // platform direction (1 = forward, -1 = backwards)
    private bool bPlayerOnPlatform = false; // check to see if player is currently on the platform

    void Update()
    {
        // platform movement
        if (bPlayerOnPlatform)
            transform.Translate(transform.right * speed * direction * Time.deltaTime);
    }


    void OnTriggerEnter(Collider col)
    {
        // EmptyGameObjects tagged "PlatformTarget" mark the two points each platform will move to 
        if (col.tag == "PlatformTarget")
        {
            // change of direction upon hitting the second point
            if (direction == 1)
                direction = -1;
            else
                direction = 1;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // player becomes child object of the platform upon touching it and mirrors its movement (to stay on top of the platform)
        if (collision.gameObject.tag == "Player")
        {
            bPlayerOnPlatform = true;
            collision.transform.parent = transform;
        }
    }

    // player is no longer the child object after leaving the platform
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
