using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour {

    public void PauseGame()
    {
        CommonGameobjects.Instance.goEventSystem.GetComponent<PauseMenuFunction>().Pause();
    }
}
