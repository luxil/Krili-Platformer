using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

    public GameObject goFinishCanvas;
    public GameObject goPlayerObject;
    public GameObject goGameOverPanel;

    private void OnTriggerEnter(Collider other)
    {
        goFinishCanvas.SetActive(true);
        goGameOverPanel.SetActive(true);
        goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = false;
    }

}
