using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuFunction : MonoBehaviour {

    public Canvas caPauseMenu;
    public GameObject goPlayerObject;
    public GameObject goPauseMenu;
    public GameObject goGameOver;

    private bool bStateChange;

    private int iCurrentScene;

    void Start ()
    {
        // disable Canvas at the start of the scene
        caPauseMenu.gameObject.SetActive(false);

        goPauseMenu.SetActive(false);
        goGameOver.SetActive(false);

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
        goPauseMenu.SetActive(true);

        // stop Player if he's currently moving
        if (goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer == true)
        {
            goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = false;
            bStateChange = true;
        }
    }


    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void Continue()
    {
        Time.timeScale = 1.0f; //unpaused
        caPauseMenu.gameObject.SetActive(false);
        goPauseMenu.SetActive(false);
        goGameOver.SetActive(false);

        // if player was stopped reactivate movement
        if (bStateChange == true)
        {
            goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = true;
            bStateChange = false;
        }
            
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f; //paused
        caPauseMenu.gameObject.SetActive(true);
        goGameOver.SetActive(true);
    }

    public void RestartLevel()
    {
        // find out current scene
        iCurrentScene = SceneManager.GetActiveScene().buildIndex;

        // reload current scene
        SceneManager.LoadScene(iCurrentScene, LoadSceneMode.Single);
    }
}
