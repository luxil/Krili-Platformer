using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    // Schnelligkeit der Plattform, public damit im editor änderbar
    public float speed = 1;

    // Richtung der Plattform. 1 = vorwärts, -1 = rückwarts
    private int direction = 1;

    //prüft, ob der Player auf der Plattform steht
    private bool bPlayerOnPlatform = false;
	
	void Update ()
    {
        // Bewegung der Plattform
        // transform.right = Vector3(1, 0, 0)
        if(bPlayerOnPlatform)
            transform.Translate(transform.right * speed * direction * Time.deltaTime);
	}


    void OnTriggerEnter(Collider col)
    {
        // Start und Zielpunkt der Plattformen sind durch EmptyGameObjects mit dem Tag "PlatformTarget" festgelegt
        if (col.tag == "PlatformTarget")
        {
            // Richtungswechsel
            if (direction == 1)
                direction = -1;
            else
                direction = 1;
        }
    }

    
    // beim Verlassen der Plattform wird der Player wieder als Child entfernt
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bPlayerOnPlatform = false;
            collision.transform.parent = null;
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        // wenn der Spieler die Plattform berührt, wird er für diese Dauer zum Child der Plattform, um die Bewegung zu übernehmen (d.h. auf der Plattform zu bleiben)
        if (collision.gameObject.tag == "Player")
        {
            bPlayerOnPlatform = true;
            collision.transform.parent = transform;
        }
    }

}
