using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuFunction : MonoBehaviour {

    private Canvas caPauseMenu;
    private GameObject goPlayerObject;
    private GameObject goPauseMenu;
    private GameObject goGameOver;

    private bool bStateChange;
    private int iCurrentScene;

    void Start ()
    {
        caPauseMenu = PreloadLevel1_Gameobjects.Instance.caPauseMenu;
        goPlayerObject = PreloadLevel1_Gameobjects.Instance.goPlayerObject;
        goPauseMenu = PreloadLevel1_Gameobjects.Instance.goPauseMenu;
        goGameOver = PreloadLevel1_Gameobjects.Instance.goGameOver;
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
        Continue();
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
