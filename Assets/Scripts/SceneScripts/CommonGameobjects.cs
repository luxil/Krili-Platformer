using UnityEngine;

public class CommonGameobjects : MonoBehaviour {

    private static CommonGameobjects instance;
    public Canvas caPauseMenu;
    public GameObject goPlayer;
    public GameObject goPauseMenu;
    public GameObject goGameOverPanel;
    public GameObject goPlayerControls;

    void Start()
    {
        instance = this;
    }

    public static CommonGameobjects Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<CommonGameobjects>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No CommonGameobjects found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }
}
