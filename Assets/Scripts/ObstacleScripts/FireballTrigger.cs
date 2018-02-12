using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrigger : MonoBehaviour {
    public GameObject goFireBall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        goFireBall.GetComponent<FireballMovement>().ActivateFireball();
    }
}
