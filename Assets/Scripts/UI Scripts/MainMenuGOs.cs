/***
 * This script is like CommonGameobjects.cs but for the main menu
 */
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGOs : MonoBehaviour {

    private static MainMenuGOs instance;
    public GameObject goEventSystem;
    public Text tCointCounter;

    void Start()
    {
        instance = this;
    }

    public static MainMenuGOs Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<MainMenuGOs>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No MainMenuGOs found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }
}
