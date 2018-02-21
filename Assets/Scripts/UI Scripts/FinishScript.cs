/***
 * This script is for handling the finish of the game
 */
using UnityEngine;

public class FinishScript : MonoBehaviour {

    private GameObject goMenuCanvas;
    private GameObject goPlayer;
    private GameObject goLevelCompletePanel;

    private void Start()
    {
        goMenuCanvas = CommonGameobjects.Instance.goMenuCanvas;
        goPlayer = CommonGameobjects.Instance.goPlayer;
        goLevelCompletePanel = CommonGameobjects.Instance.goLevelCompletePanel;
    }

    private void OnTriggerEnter(Collider other)
    {
        //activate finish window
        goMenuCanvas.SetActive(true);
        goLevelCompletePanel.SetActive(true);
        goPlayer.GetComponent<PlayerMovement>().bMovePlayer = false;
    }

}
