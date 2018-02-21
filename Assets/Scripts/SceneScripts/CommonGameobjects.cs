/***
 * Ín this script are all important GameObjects, which you could call in other scripts with CommonGameobjects.Instance.[name of the gameobject].
 * So you don't have to drag and drop the objects in the editor for other scripts.
 * The reason why you should not use drag and drop: If you use git with other contributors they have to drag and drop the objects in ALL gameobjects, too.
 * Which could be painful if you have many different gameobjects.
 * With this method they only have to drag and drop the objects in this CommonGameobjects script
 */

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
