using UnityEngine;

public class Level01Gameobjects : MonoBehaviour {

    private static Level01Gameobjects instance;
    public Canvas caPauseMenu;
    public GameObject goPlayerObject;
    public GameObject goPauseMenu;
    public GameObject goGameOver;
    public GameObject goInGameMenuControl;

    void Start()
    {
        instance = this;
    }

    public static Level01Gameobjects Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<Level01Gameobjects>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No Level01Gameobjects found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }
}
