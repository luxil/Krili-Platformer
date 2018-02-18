using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpScript : MonoBehaviour {

    private GameObject goPlayerControls;

    // Use this for initialization
    void Start()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls;
    }

    //if player collides with coin then pick it up
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<CoinControlScript>().AddCoins(1);
            Destroy(gameObject);
        }
    }
}
