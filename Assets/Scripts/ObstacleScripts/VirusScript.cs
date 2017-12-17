using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour {

    //variables needed for the enemy movement
    public float fSpeed = 5.0f;
    private int iDirection = 1;     // (1 = up, -1 = down)
    public float fLimit = 5.0f;       // max distance the enemy can move upwards
    private Vector3 v3StartPos;

    // variables needed for player health reduction
    public GameObject goInGameControl;
    public GameObject goPlayer;


    void Start()
    {
        v3StartPos = transform.position;    // get starting postion
    }

    void Update()
    {

        // set direction
        if (transform.position.y > v3StartPos.y + fLimit)   // if position is greater than starting position + limit, change direction
            iDirection = -1;
        else if (transform.position.y < v3StartPos.y)       // go up if current position is smaller than starting position
            iDirection = 1;

        transform.Translate(transform.up * fSpeed * iDirection * Time.deltaTime);   // transform.up -> Vector3(0, 1, 0)
    }

    // reduce player health on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goInGameControl.GetComponent<HealthControlScript>().reduceHearts(1);
            goPlayer.GetComponent<PlayerHitScript>().playerGotHurt();
        }
    }
}
