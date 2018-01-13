using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour {

    public GameObject goMainMenuContainer;
    public GameObject goLevelPanel;

    void Start()
    {
        // disable Level selection at the start of the scene
        goLevelPanel.SetActive(false);
    }

    public void PlayGame()
    {
        goMainMenuContainer.SetActive(false);
        goLevelPanel.SetActive(true);
    }

    public void LoadLevel(string selectedLevel)
    {
        // String has to be the Name of the scene!
        SceneManager.LoadScene(selectedLevel);
    }

    public void CloseLevelSelection()
    {
        goMainMenuContainer.SetActive(true);
        goLevelPanel.SetActive(false);
    }

    public void EndGame()
    {
        
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }

}
