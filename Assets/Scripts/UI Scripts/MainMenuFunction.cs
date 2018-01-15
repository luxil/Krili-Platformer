using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour {

    public GameObject goMainMenuContainer;
    public GameObject goLevelPanel;
    public GameObject goInfoPanel;
    public GameObject goShopCanvas;

    void Start()
    {
        // Level selection and info panel at the start of the scene
        goMainMenuContainer.transform.parent.gameObject.SetActive(true);
        goLevelPanel.SetActive(false);
        goInfoPanel.SetActive(false);
        goShopCanvas.SetActive(false);
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

    public void OpenGameInfo()
    {
        goMainMenuContainer.SetActive(false);
        goInfoPanel.SetActive(true);
    }

    public void CloseGameInfo()
    {
        goMainMenuContainer.SetActive(true);
        goInfoPanel.SetActive(false);
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
