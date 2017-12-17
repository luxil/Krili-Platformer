using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

    public GameObject goFinishCanvas;
    public GameObject goPlayerObject;

    private void OnTriggerEnter(Collider other)
    {
        goFinishCanvas.SetActive(true);
        goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = false;
    }

}
