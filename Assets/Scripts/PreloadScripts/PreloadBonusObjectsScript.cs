using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadBonusObjectsScript : MonoBehaviour
{
    private static PreloadBonusObjectsScript instance;
    public BonusObject[] boArrBonusObjects;
    private int iCurrentBonusObject;

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
        get {return iCurrentBonusObject;}
        set {iCurrentBonusObject = value;}
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
}
