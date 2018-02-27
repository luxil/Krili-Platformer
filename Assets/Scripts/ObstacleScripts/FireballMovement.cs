/**********************************************
*   script to handle fireball movement
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    private float fFlyingSpeed = 10;    //speed of the fireball
    private float fTimeDestroy = 5f;    //time after which the fireball should be destroyed
    private bool bMoveFireBall = false;
    private float fStartTime;


    void Update () {
        //move fireball 
        if (fStartTime + fTimeDestroy > Time.time && bMoveFireBall)
        {
            transform.Translate(Vector3.left * Time.deltaTime * fFlyingSpeed, Space.World);
        }
        //destroy fireball
        else if(fStartTime + fTimeDestroy < Time.time && bMoveFireBall)
        {
            Destroy(gameObject);
        }
    }

    // this function is called by FireballTrigger.cs and starts the fireball movement
    public void ActivateFireball()
    {
        bMoveFireBall = true;
        fStartTime = Time.time;
    }


}
