using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuFunction : MonoBehaviour {

    public Canvas pauseCanvas;

    public GameObject playerObject;

    private bool bStateChange;

    void Start ()
    {
        // disable Canvas at the start of the scene
        pauseCanvas.gameObject.SetActive(false);
        bStateChange = false;
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

        // stop Player if he's currently moving
        if (playerObject.GetComponent<PlayerMovement>().bMovePlayer == true)
        {
            playerObject.GetComponent<PlayerMovement>().bMovePlayer = false;
            bStateChange = true;
        }
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

        // if player was stopped reactivate movement
        if(bStateChange == true)
        {
            playerObject.GetComponent<PlayerMovement>().bMovePlayer = true;
            bStateChange = false;
        }
            
    }
}
