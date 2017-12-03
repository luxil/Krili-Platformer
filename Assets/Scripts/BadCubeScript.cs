﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCubeScript : MonoBehaviour {

    //https://www.mpgh.net/forum/showthread.php?t=427244
    //get GameObject InGameControl in Canvas
    public GameObject goInGameControl;
    HealthControlScript htsScript;

    // Use this for initialization
    void Start () {
        htsScript = goInGameControl.GetComponent<HealthControlScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if player collides with coin then reduce his health
        if (collision.gameObject.tag == "Player")
        {
            htsScript.reduceHearts(1);
        }

        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //    gameControlScript.reduceHearts(1);
        //}
    }

}
