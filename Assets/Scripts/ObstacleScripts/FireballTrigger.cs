using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrigger : MonoBehaviour {

    public GameObject goFireBall;

    //activate fireball if player enter this trigger
    private void OnTriggerEnter(Collider other)
    {
        goFireBall.GetComponent<FireballMovement>().ActivateFireball();
    }
}
