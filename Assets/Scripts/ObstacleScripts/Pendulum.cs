using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    // variables needed for the pendulum
    public float fSpeed = 1.0f;     // speed at which the pendulum swings
    public float fAmplitude = 65;   // amplitude

    // variables needed for health reduction
    public GameObject goInGameControl;
    public GameObject goPlayer;

    void Update () {

        ///  <summary>
        ///     Quaternion Euler(float x, float y, float z);
        ///     Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).
        ///  </summary>

        transform.rotation = Quaternion.Euler(Mathf.Sin(Time.time * fSpeed) * fAmplitude, 0, 0);
        //transform.rotation = Quaternion.Euler(Mathf.Sin(Time.time * Mathf.PI * fSpeed) * fAmplitude, 0, 0);

    }

    // see BadCubeScript
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            goInGameControl.GetComponent<HealthControlScript>().reduceHearts(1);
            goPlayer.GetComponent<PlayerHitScript>().playerGotHurt();
        }
    }
}
