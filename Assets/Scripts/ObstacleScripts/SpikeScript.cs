using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {

    //https://www.mpgh.net/forum/showthread.php?t=427244
    //get GameObject InGameControl in Canvas
    public GameObject goInGameControl;
    public GameObject goPlayer;

    private void Awake()
    {
        goInGameControl = GameObject.Find("InGameMenuControl");
        goPlayer = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        //player got hit 
        if (other.gameObject.tag == "Player")
        {
            goInGameControl.GetComponent<HealthControlScript>().reduceHearts(1);
            goPlayer.GetComponent<PlayerHitScript>().playerGotHurt();
        }
    }
}
