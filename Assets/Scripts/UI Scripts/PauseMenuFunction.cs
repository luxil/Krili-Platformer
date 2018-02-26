
/**********************************************
*   script to handle the pause menu
*   (which also includes the game over panel and the next level panel)
**********************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuFunction : MonoBehaviour {

    private GameObject goPlayerObject;
    private GameObject goMenuCanvas;
    private GameObject goGameOver;
	private GameObject goPausePanel;

    private bool bStateChange;  // indicates if the player had to be stopped while displaying the pause menu
    private int iCurrentScene;

    void Start ()
    {
        goPlayerObject = CommonGameobjects.Instance.goPlayer;
        goMenuCanvas = CommonGameobjects.Instance.goMenuCanvas;
		goPausePanel = CommonGameobjects.Instance.goPausePanel;
        goGameOver = CommonGameobjects.Instance.goGameOverPanel;

        // disable Canvas at the start of the scene
        goMenuCanvas.SetActive(false);
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
        goMenuCanvas.SetActive(true);
		goPausePanel.SetActive(true);

        // stop Player if he's currently moving and change bStateChange accordingly
        if (goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer == true)
        {
            goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = false;
            bStateChange = true;
        }
    }


    public void GoBack()
    {
        Continue();
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Time.timeScale = 1.0f; //unpaused
        // deactivate any canvases
        goMenuCanvas.SetActive(false);
        goGameOver.SetActive(false);
		goPausePanel.SetActive(false);

        // if player was stopped reactivate movement and change status of bStateChange
        if (bStateChange == true)
        {
            goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = true;
            bStateChange = false;
        }
            
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f; //paused
        goPlayerObject.GetComponent<PlayerMovement>().bMovePlayer = false; //stop player movement
        goMenuCanvas.SetActive(true);
        goGameOver.SetActive(true);
    }

    public void RestartLevel()
    {
        // find out current scene
        iCurrentScene = SceneManager.GetActiveScene().buildIndex;

        // reload current scene
        SceneManager.LoadScene(iCurrentScene, LoadSceneMode.Single);
    }

    /// <summary>
    ///  This function is supplied with a String that can be set in the inspector in Unity.
    ///  This is done so that the same function can be used by different objects,
    ///  but each loading different scenes. 
    /// </summary>

    public void NextLevel(string nextLevel)
    {
        // String typed in the inspector has to be the name of the scene!
        SceneManager.LoadScene(nextLevel);
    }
}
