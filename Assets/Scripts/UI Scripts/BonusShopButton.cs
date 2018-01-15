using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusShopButton : MonoBehaviour {
    public GameObject go__bonusObjects;
    public BonusObject [] goArrBonusObjects;
    public int ICurrentIndex;

    public Text tName;
    public Text tCost;
    public Text tDescription;

    private void Awake()
    {
        go__bonusObjects = GameObject.Find("__bonusObjects");
        goArrBonusObjects = go__bonusObjects.GetComponent<PreloadBonusObjectsScript>().boArrBonusObjects;
        setButton();
    }

    void setButton()
    {
        tName.text = goArrBonusObjects[ICurrentIndex].sBonusName;
        tCost.text = goArrBonusObjects[ICurrentIndex].iCost.ToString();
        tDescription.text = goArrBonusObjects[ICurrentIndex].sDescription;
    }
}
