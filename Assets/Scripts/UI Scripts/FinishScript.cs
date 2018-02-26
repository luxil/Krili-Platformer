
/**********************************************
*   script to handle completing a level
**********************************************/

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

    // this function is called when the player enters the trigger on the finish particle system
    private void OnTriggerEnter(Collider other)
    {
        //activate finish window and stop player movement
        goMenuCanvas.SetActive(true);
        goLevelCompletePanel.SetActive(true);
        goPlayer.GetComponent<PlayerMovement>().bMovePlayer = false;
    }

}
