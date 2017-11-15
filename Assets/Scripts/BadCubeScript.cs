using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCubeScript : MonoBehaviour {

    //https://www.mpgh.net/forum/showthread.php?t=427244

    public GameObject gameControl;
    GameControlScript gameControlScript;
    public float collisionTime;

    // Use this for initialization
    void Start () {
        gameControlScript = gameControl.GetComponent<GameControlScript>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
            gameControlScript.reduceHearts(1);

        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //    gameControlScript.reduceHearts(1);
        //}
    }

}
