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
        activateBonusObject(iCurrentBonusObject);
        activateBonusObject(iCurrentBonusObject2);

        //delete Bonusobjects from inventory
        PreloadBonusObjectsScript.Instance.ICurrentBonusObject = -1;
        PreloadBonusObjectsScript.Instance.ICurrentBonusObject2 = -1;
        PreloadPlayerData.Instance.RemoveFromIvList(iCurrentBonusObject);
        PreloadPlayerData.Instance.RemoveFromIvList(iCurrentBonusObject2);
    }

    private void Update()
    {
        
    }

    private void activateBonusObject(int iIndexBO)
    {
        switch (iIndexBO)
        {
            //double coin
            case 0:
                gameObject.GetComponent<CoinControlScript>().updateCoinCounterFactor(2);

                //only needed when the bonusobject has a time limit, need to be put in Update()
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

            //shield is active
            case 1:
                gameObject.GetComponent<HealthControlScript>().activateShield();
                break;

            default:
                //Debug.Log("no bonus object");
                break;
        }
    }


}
