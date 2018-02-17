using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour {
    public void Restart()
    {
        CommonGameobjects.Instance.goEventSystem.GetComponent<PauseMenuFunction>().RestartLevel();
    }

    public void Quit()
    {
        CommonGameobjects.Instance.goEventSystem.GetComponent<PauseMenuFunction>().GoBack();
    }
}
