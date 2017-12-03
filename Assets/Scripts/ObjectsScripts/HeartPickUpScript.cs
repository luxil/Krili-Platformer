using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUpScript : MonoBehaviour {
    //get GameObject InGameControl in Canvas
    public GameObject goInGameControl;
    HealthControlScript htsScript;

    // Use this for initialization
    void Start()
    {
        htsScript = goInGameControl.GetComponent<HealthControlScript>();
    }

    //if player collides with heart then pick it up
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            htsScript.addHearts(1);
            Destroy(gameObject);
        }
    }
}
