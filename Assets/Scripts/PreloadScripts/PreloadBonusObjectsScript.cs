using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadBonusObjectsScript : MonoBehaviour
{
    private static PreloadBonusObjectsScript instance;
    public BonusObject[] boArrBonusObjects;
    private int iCurrentBonusObject = -1;
    private int iCurrentBonusObject2 = -1;
    private int iMaxCurrentBonusObjects = 2;

    void Awake () {
        //*set instance
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        //Keep the PreloadBonusObjectsScript even if loading level.
        DontDestroyOnLoad(this.gameObject); 
        instance = this;
        //*end set instance

        //load main menu
        SceneManager.LoadScene(1);
    }

    public int ICurrentBonusObject
    {
        get
        {
            return iCurrentBonusObject;
        }
        set
        {
            iCurrentBonusObject = value;
        }
    }

    public static PreloadBonusObjectsScript Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<PreloadBonusObjectsScript>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No PreloadBonusObjectsScript found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }

    public int ICurrentBonusObject2
    {
        get
        {
            return iCurrentBonusObject2;
        }

        set
        {
            iCurrentBonusObject2 = value;
        }
    }

    public int IMaxCurrentBonusObjects
    {
        get
        {
            return iMaxCurrentBonusObjects;
        }

        set
        {
            iMaxCurrentBonusObjects = value;
        }
    }
}
