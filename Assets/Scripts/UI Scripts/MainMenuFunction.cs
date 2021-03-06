﻿/**********************************************
*   script to handle the main menu
**********************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour {

    public GameObject goMainMenuContainer;
    public GameObject goLevelPanel;
    public GameObject goInfoPanel;
    public GameObject goShopCanvas;
    public GameObject goCreditsPanel;

    void Start()
    {
        // turn off all unneeded panels, make sure MainMenuContainer is active
        goMainMenuContainer.transform.parent.gameObject.SetActive(true);
        goMainMenuContainer.SetActive(true);
        goLevelPanel.SetActive(false);
        goInfoPanel.SetActive(false);
        goShopCanvas.SetActive(false);
        goCreditsPanel.SetActive(false);
    }


    /****************************************************
     * Start/ Close Game
     ****************************************************/
    public void PlayGame()
    {
        goMainMenuContainer.SetActive(false);
        goLevelPanel.SetActive(true);
    }

    public void EndGame()
    {
        // included unity_editor for testing purposes
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }


    /****************************************************
     * Turn Level Selection on/off
     ****************************************************/

    /// <summary>
    ///  This function is supplied with a String that can be set in the inspector in Unity.
    ///  This is done so that the same function can be used by different objects,
    ///  but each loading different scenes. 
    /// </summary>

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


    /****************************************************
     * Open/Close Game Info
     ****************************************************/
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


    /****************************************************
     * Open/Close Credits Panel
     ****************************************************/
    public void OpenCredit()
    {
        goInfoPanel.SetActive(false);
        goCreditsPanel.SetActive(true);
    }

    public void CloseCredit()
    {
        goCreditsPanel.SetActive(false);
        goInfoPanel.SetActive(true);
    }

    

}
