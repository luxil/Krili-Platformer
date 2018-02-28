
/**********************************************
*   This script handles the pause panel
**********************************************/

using UnityEngine;

public class PausePanel : MonoBehaviour {
    public void Continue()
    {
        CommonGameobjects.Instance.goEventSystem.GetComponent<PauseMenuFunction>().Continue();
    }

    public void Quit()
    {
        CommonGameobjects.Instance.goEventSystem.GetComponent<PauseMenuFunction>().GoBack();
    }
}
