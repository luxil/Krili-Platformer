using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusShopButton : MonoBehaviour {

    PreloadPlayerData ppdata;
    public BonusObject [] goArrBonusObjects;
    public int iCurrentBO;

    public Text tName;
    public Text tCost;
    public Text tDescription;

    private void Start()
    {
        ppdata = PreloadPlayerData.Instance;
        MainMenuGOs.Instance.tCointCounter.text = ppdata.ICoinCount.ToString();
        goArrBonusObjects = PreloadBonusObjectsScript.Instance.boArrBonusObjects;
        setButton();
    }

    void setButton()
    {
        tName.text = goArrBonusObjects[iCurrentBO].sBonusName;
        tCost.text = goArrBonusObjects[iCurrentBO].iCost.ToString();
        tDescription.text = goArrBonusObjects[iCurrentBO].sDescription;
    }

    public void OnClick()
    {
        if(ppdata.ICoinCount >= goArrBonusObjects[iCurrentBO].iCost &&
            ppdata.iListInventarBO.Count < ppdata.IMaxBO)
        {
            ppdata.ICoinCount -= goArrBonusObjects[iCurrentBO].iCost;
            ppdata.iListInventarBO.Add(iCurrentBO);
            ppdata.SavePlayerData();
            MainMenuGOs.Instance.tCointCounter.text = ppdata.ICoinCount.ToString();
        }
        else
        {
            Debug.Log("Not enough money or no space anymore");
        }
    }
}
