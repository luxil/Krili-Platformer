using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDead : MonoBehaviour {

    bool falling= false; // tells when the player is falling 
    private float lastY; // last grounded height 
    private CharacterController character;

	// Use this for initialization
	void Start () {
        character = GetComponent<CharacterController>();
        lastY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (character.isGrounded == false)
        { // if character not grounded... 
            Debug.Log("not grounded");
            falling = true; // assume it's falling 
        } else { // if character grounded... 
            if (falling){ // but was falling last update... 
                var hFall = lastY - transform.position.y;
                // calculate the fall height... 
                if (hFall > 8){ // then check the damage/death // player is dead 
                    Debug.Log("PLAYER DEAD");
                } } lastY = transform.position.y; // update lastY when character grounded 
        }
    }
}
