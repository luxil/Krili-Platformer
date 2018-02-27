
/**********************************************
*   script to handle picking up hearts
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUpScript : MonoBehaviour {

    private GameObject goPlayerControls;


    void Start()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls; 
    }

    //if player collides with heart pick it up
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<HealthControlScript>().AddHearts(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<HealthControlScript>().AddHearts(1);
            Destroy(gameObject);
        }
    }
}
