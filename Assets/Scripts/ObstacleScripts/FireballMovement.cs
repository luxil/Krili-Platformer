using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {
    private float fFlyingSpeed = -0.25f;
    private float fTimeDestroy = 5f;
    public bool bMoveFireBall = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bMoveFireBall)
        {
            transform.Translate(fFlyingSpeed, 0, 0);
        }
    }

    public void ActivateFireball()
    {
        bMoveFireBall = true;
    }


}
