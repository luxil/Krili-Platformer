using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDead : MonoBehaviour {

    // tells when the player is falling 
    bool falling = false;
    // last grounded height 
    private float lastY; 
    private CharacterController ccCharacter;

	// Use this for initialization
	void Start () {
        ccCharacter = GetComponent<CharacterController>();
        lastY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        // if character not grounded... 
        if (ccCharacter.isGrounded == false)
        {
            // assume it's falling 
            falling = true; 
        // if character grounded... 
        }
        else { 
            // but was falling on last update... 
            if (falling){
                // calculate the fall height... 
                var hFall = lastY - transform.position.y;
                // then check the damage/death 
                if (hFall > 8){
                    // player is dead 
                    CommonGameobjects.Instance.goMenuCanvas.SetActive(true);
                    CommonGameobjects.Instance.goGameOverPanel.SetActive(true);
                }
            }
            // update lastY when character grounded 
            lastY = transform.position.y; 
        }
    }
}
