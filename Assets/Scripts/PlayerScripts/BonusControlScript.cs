using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControlScript : MonoBehaviour {
    public BonusObject[] goArrBonusObjects;
    public int iCurrentBonusObject = 0;
    float fTimeLeftDoubleCoins;
    public GameObject go__bonusObjects;

    public void Start()
    {
        go__bonusObjects = GameObject.Find("__bonusObjects");
        goArrBonusObjects = go__bonusObjects.GetComponent<PreloadBonusObjectsScript>().boArrBonusObjects;
        iCurrentBonusObject = go__bonusObjects.GetComponent<PreloadBonusObjectsScript>().getICurrentBonusObject();
    }

    private void Update()
    {
        switch (iCurrentBonusObject)
        {
            //double coin
            case 0:
                gameObject.GetComponent<CoinControlScript>().updateCoinCounterFactor(2);
                fTimeLeftDoubleCoins += Time.deltaTime;
                //Debug.Log(goArrBonusObjects.Length);
                if (fTimeLeftDoubleCoins > goArrBonusObjects[iCurrentBonusObject].fDuration)
                {
                    //Debug.Log("Stop double coins");
                    gameObject.GetComponent<CoinControlScript>().updateCoinCounterFactor(1);
                    iCurrentBonusObject = 0;
                }
                break;

            default:
                //Debug.Log("no bonus object");
                break;
        }
    }


}
