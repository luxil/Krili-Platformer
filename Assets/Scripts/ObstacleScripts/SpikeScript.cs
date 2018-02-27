/**********************************************
*   script to handle spike obstacles
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour {

    /**********************************************
    *   this script is based on
    *   https://www.mpgh.net/forum/showthread.php?t=427244
    **********************************************/

    private GameObject goPlayerControls;
    private GameObject goPlayer;

    private void Awake()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls;
        goPlayer = CommonGameobjects.Instance.goPlayer;
    }

    // reduce hearts when the player enters the spike's trigger
    private void OnTriggerEnter(Collider other)
    {
        //player got hit 
        if (other.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<HealthControlScript>().ReduceHearts(1);
            goPlayer.GetComponent<PlayerHitScript>().PlayerGotHurt();
        }
    }
}
