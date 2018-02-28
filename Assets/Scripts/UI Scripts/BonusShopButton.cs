
/**********************************************
*   script to handle the functionality of the bonus shop button
**********************************************/

using UnityEngine;
using UnityEngine.UI;

public class BonusShopButton : MonoBehaviour {

    PreloadPlayerData ppdata;
    public BonusObject [] goArrBonusObjects;
    public int iCurrentBO;

    //these text variables should display the bonus object information
    public Text tName;
    public Text tCost;
    public Text tDescription;

    private void Start()
    {
        ppdata = PreloadPlayerData.Instance;
        MainMenuGOs.Instance.tCointCounter.text = ppdata.ICoinCount.ToString();
        goArrBonusObjects = PreloadBonusObjectsScript.Instance.boArrBonusObjects;
        SetButton();
    }

    //put information of the bonusobject in the button
    void SetButton()
    {
        tName.text = goArrBonusObjects[iCurrentBO].sBonusName;
        tCost.text = goArrBonusObjects[iCurrentBO].iCost.ToString();
        tDescription.text = goArrBonusObjects[iCurrentBO].sDescription;
    }

    public void OnClick()
    {
        //check whether the player has enough coins and space in the inventory
        if (ppdata.ICoinCount >= goArrBonusObjects[iCurrentBO].iCost && ppdata.iListInventarBO.Count < ppdata.IMaxBO)
        {
            //buy bonusobject and add it to the inventory; reduce coins
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
