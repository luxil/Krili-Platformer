using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    // Schnelligkeit der Plattform, public damit im editor änderbar
    public float speed = 1;

    // Richtung der Plattform. 1 = vorwärts, -1 = rückwarts
    private int direction = 1;
	
	
	void Update ()
    {
        // Bewegung der Plattform
        // transform.right = Vector3(1, 0, 0)
        transform.Translate(transform.right * speed * direction * Time.deltaTime);
	}


    void OnTriggerEnter(Collider other)
    {
        // Start und Zielpunkt der Plattformen sind durch EmptyGameObjects mit dem Tag "PlatformTarget" festgelegt
        if (other.tag == "PlatformTarget")
        {
            // Richtungswechsel
            if (direction == 1)
                direction = -1;
            else
                direction = 1;
        }
    }

}
