using UnityEngine;

public class PreloadLevel1_Gameobjects : MonoBehaviour {

    private static PreloadLevel1_Gameobjects instance;
    public Canvas caPauseMenu;
    public GameObject goPlayerObject;
    public GameObject goPauseMenu;
    public GameObject goGameOver;
    public GameObject goInGameMenuControl;

    void Start()
    {
        instance = this;
    }

    public static PreloadLevel1_Gameobjects Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<PreloadLevel1_Gameobjects>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No PreloadLevel1_Gameobjects found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }
}
