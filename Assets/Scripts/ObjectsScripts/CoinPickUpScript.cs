
/**********************************************
*   script to handle picking up coins
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpScript : MonoBehaviour {

    private GameObject goPlayerControls;


    void Start()
    {
        goPlayerControls = CommonGameobjects.Instance.goPlayerControls;
    }

    //if player collides with coin pick it up
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<CoinControlScript>().AddCoins(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goPlayerControls.GetComponent<CoinControlScript>().AddCoins(1);
            Destroy(gameObject);
        }
    }
}
