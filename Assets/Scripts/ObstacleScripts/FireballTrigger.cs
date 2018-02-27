/**********************************************
*   script to handle the fireball triggers
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrigger : MonoBehaviour {

    public GameObject goFireBall;

    //activate fireball if player enters this trigger
    private void OnTriggerEnter(Collider other)
    {
        goFireBall.GetComponent<FireballMovement>().ActivateFireball();
    }
}
