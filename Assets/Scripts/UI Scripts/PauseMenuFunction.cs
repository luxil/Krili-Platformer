using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuFunction : MonoBehaviour {

    public Canvas caPauseMenu;

    public GameObject goPlayerObject;

    private bool bStateChange;

    void Start ()
    {
        // disable Canvas at the start of the scene
        caPauseMenu.gameObject.SetActive(false);
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
        caPauseMenu.gameObject.SetActive(true);

        // stop Player if he's currently moving
        if (goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer == true)
        {
            goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = false;
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
        caPauseMenu.gameObject.SetActive(false);

        // if player was stopped reactivate movement
        if(bStateChange == true)
        {
            goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = true;
            bStateChange = false;
        }
            
    }
}
