using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    //speed of the fireball
    private float fFlyingSpeed = 10;
    //time after the fireball should be destroyed
    private float fTimeDestroy = 5f;
    private bool bMoveFireBall = false;
    private float fStartTime;


    // Update is called once per frame
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

    public void ActivateFireball()
    {
        bMoveFireBall = true;
        fStartTime = Time.time;
    }


}
