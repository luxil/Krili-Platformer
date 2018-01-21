using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpScript : MonoBehaviour {

    //get GameObject InGameControl in Canvas
    private GameObject goPlayerControls;
    CoinControlScript ccsScript;

    // Use this for initialization
    void Start()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls;
        ccsScript = goPlayerControls.GetComponent<CoinControlScript>();
    }

    //if player collides with coin then pick it up
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ccsScript.addCoins(1);
            Destroy(gameObject);
        }
    }
}
