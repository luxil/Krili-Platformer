/// <summary>
/// This scripts includes all the GameObjects which are called in other scripts with CommonGameobjects.Instance.[name of the gameobject].
/// This is done so the objects don't have to be dragged and dropped in the unity editor for the other scripts.
/// The reason why drag and drop shouldn't be used: If you use git with other contributors they have to drag and drop EACH gameobject into the script, too.
/// This is quite time consuming and annoying, especially if the project has many different gameobjects used by different scripts.
/// With this method the objects have to be draged and dropped only once into this CommonGameobjects script.
/// </summary>


using UnityEngine;

public class CommonGameobjects : MonoBehaviour {

    private static CommonGameobjects instance;
    public GameObject goPlayer;
    public GameObject goMenuCanvas;
    public GameObject goGameOverPanel;
    public GameObject goPlayerControls;
    public GameObject goEventSystem;
	public GameObject goLevelCompletePanel;
    public GameObject goPausePanel;

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
