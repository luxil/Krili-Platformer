using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuFunction : MonoBehaviour {

    public Canvas pauseCanvas;

    void Start ()
    {
        // disable Canvas at the start of the scene
        pauseCanvas.gameObject.SetActive(false);
	}
	

	void Update ()
    {
        // for PC: pause game when esc is clicked
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }


    public void Pause()
    {
            Time.timeScale = 0.0f; //paused
            pauseCanvas.gameObject.SetActive(true);
    }


    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit ();
        #endif
    }


    public void Continue()
    {
        Time.timeScale = 1.0f; //unpaused
        pauseCanvas.gameObject.SetActive(false);
    }
}
