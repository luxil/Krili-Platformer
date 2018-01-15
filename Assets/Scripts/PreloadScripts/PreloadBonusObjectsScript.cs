using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadBonusObjectsScript : MonoBehaviour {
    public BonusObject[] boArrBonusObjects;
    private int iCoinNumber;
    private int iCurrentBonusObject;

    void Awake () {
        iCoinNumber = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
	
    public int getICurrentBonusObject()
    {
        return iCurrentBonusObject;
    }

    public void setICurrentBonusObject(int id)
    {
        iCurrentBonusObject = id;
    }
}
