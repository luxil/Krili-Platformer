using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusShopButton : MonoBehaviour {
    //public GameObject go__app;
    public BonusObject [] goArrBonusObjects;
    public int iIndex;

    public Text tName;
    public Text tCost;
    public Text tDescription;

    private void Awake()
    {
        //goArrBonusObjects = go__app.GetComponent<PreloadBonusObjectsScript>().boArrBonusObjects;
        goArrBonusObjects = PreloadBonusObjectsScript.instance.boArrBonusObjects;
        setButton();
    }

    void setButton()
    {
        tName.text = goArrBonusObjects[iIndex].sBonusName;
        tCost.text = goArrBonusObjects[iIndex].iCost.ToString();
        tDescription.text = goArrBonusObjects[iIndex].sDescription;
    }
}
