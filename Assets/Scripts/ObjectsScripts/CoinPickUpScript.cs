using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpScript : MonoBehaviour {

    //get GameObject InGameControl in Canvas
    public GameObject goInGameControl;
    CoinControlScript ccsScript;

    // Use this for initialization
    void Start()
    {
        Debug.Log("satrt coin");
        ccsScript = goInGameControl.GetComponent<CoinControlScript>();
    }

    //if player collides with coin then pick it up
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            ccsScript.addCoins(1);
            Destroy(gameObject);
        }
    }
}
