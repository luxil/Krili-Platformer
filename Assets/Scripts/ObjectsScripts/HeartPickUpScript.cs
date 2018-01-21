using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUpScript : MonoBehaviour {
    private GameObject goPlayerControls;
    HealthControlScript htsScript;

    // Use this for initialization
    void Start()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls; 
        htsScript = goPlayerControls.GetComponent<HealthControlScript>();
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
