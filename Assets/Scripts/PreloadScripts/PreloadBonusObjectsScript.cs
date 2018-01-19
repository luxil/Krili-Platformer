using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadBonusObjectsScript : MonoBehaviour
{ 
    public static PreloadBonusObjectsScript instance;
    public BonusObject[] boArrBonusObjects;
    private int iCurrentBonusObject;

    void Awake () {
        instance = this;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
}
