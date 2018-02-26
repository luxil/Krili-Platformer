
/**********************************************
*   script to handle all bonusobjects in the inventory
**********************************************/


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

                /// <summary>
                /// The following code is only needed when the bonusobject has a time limit. Needs to be put in Update().
                /// For now, we decided to remove the time limit from the current bonus objects, but kept the code 
                /// in case we decide to re-add bonus objects with a time limit.
                /// </summary>

/*                  fTimeLeftDoubleCoins += Time.deltaTime;
                    //Debug.Log(goArrBonusObjects.Length);
                    if (fTimeLeftDoubleCoins > goArrBonusObjects[iCurrentBonusObject].fDuration)
                    {
                        //Debug.Log("Stop double coins");
                        gameObject.GetComponent<CoinControlScript>().updateCoinCounterFactor(1);
                        iCurrentBonusObject = 0;
                    }
*/
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
