/***
 *  script to handle all bonusobjects in the inventory
 * 
 * 
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControlScript : MonoBehaviour {
    public BonusObject[] goArrBonusObjects;
    public int iCurrentBonusObject;
    public int iCurrentBonusObject2;
    float fTimeLeftDoubleCoins;

    public void Start()
    {
        goArrBonusObjects = PreloadBonusObjectsScript.Instance.boArrBonusObjects;
        iCurrentBonusObject = PreloadBonusObjectsScript.Instance.ICurrentBonusObject;
        iCurrentBonusObject2 = PreloadBonusObjectsScript.Instance.ICurrentBonusObject2;
        ActivateBonusObject(iCurrentBonusObject);
        ActivateBonusObject(iCurrentBonusObject2);

        //delete Bonusobjects from inventory
        PreloadBonusObjectsScript.Instance.ICurrentBonusObject = -1;
        PreloadBonusObjectsScript.Instance.ICurrentBonusObject2 = -1;
        PreloadPlayerData.Instance.RemoveFromIvList(iCurrentBonusObject);
        PreloadPlayerData.Instance.RemoveFromIvList(iCurrentBonusObject2);

        PreloadPlayerData.Instance.SavePlayerData();
    }

    private void ActivateBonusObject(int iIndexBO)
    {
        switch (iIndexBO)
        {
            //double coin
            case 0:
                gameObject.GetComponent<CoinControlScript>().UpdateCoinCounterFactor(2);

                //only needed when the bonusobject has a time limit, need to be put in Update()
                //maybe needed later when more bonusobjects should be added
                /*
                fTimeLeftDoubleCoins += Time.deltaTime;
                //Debug.Log(goArrBonusObjects.Length);
                if (fTimeLeftDoubleCoins > goArrBonusObjects[iCurrentBonusObject].fDuration)
                {
                    //Debug.Log("Stop double coins");
                    gameObject.GetComponent<CoinControlScript>().updateCoinCounterFactor(1);
                    iCurrentBonusObject = 0;
                }*/
                break;

            //shield 
            case 1:
                gameObject.GetComponent<HealthControlScript>().ActivateShield();
                break;

            default:
                break;
        }
    }


}
