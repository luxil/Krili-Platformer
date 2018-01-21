using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

    private GameObject goMenuCanvas;
    private GameObject goPlayer;
    private GameObject goGameOverPanel;

    private void Start()
    {
        goMenuCanvas = CommonGameobjects.Instance.goMenuCanvas;
        goPlayer = CommonGameobjects.Instance.goPlayer;
        goGameOverPanel = CommonGameobjects.Instance.goGameOverPanel;
    }

    private void OnTriggerEnter(Collider other)
    {
        goMenuCanvas.SetActive(true);
        goGameOverPanel.SetActive(true);
        goPlayer.GetComponent<PlayerMovement>().bMovePlayer = false;
    }

}
