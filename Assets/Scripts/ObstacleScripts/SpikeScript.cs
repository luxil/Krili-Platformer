using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {

    //https://www.mpgh.net/forum/showthread.php?t=427244
    //get GameObject InGameControl in Canvas
    private GameObject goPlayerControls;
    private GameObject goPlayer;

    private void Awake()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls;
        goPlayer = CommonGameobjects.Instance.goPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        //player got hit 
        if (other.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<HealthControlScript>().reduceHearts(1);
            goPlayer.GetComponent<PlayerHitScript>().playerGotHurt();
        }
    }
}
