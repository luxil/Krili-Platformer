
/**********************************************
*   This script handles the pause in an easy way
**********************************************/

using UnityEngine;

public class PlayerPause : MonoBehaviour {

    public void PauseGame()
    {
        CommonGameobjects.Instance.goEventSystem.GetComponent<PauseMenuFunction>().Pause();
    }
}
