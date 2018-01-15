using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControlScript : MonoBehaviour {
    public BonusObject[] bonusObjects;
    public int iCurrentBonusObject = 0;

    private void Update()
    {
        switch (iCurrentBonusObject)
        {
            //double coin
            case 1:
                gameObject.GetComponent<CoinControlScript>().updateCoinCounterFactor(2);
                break;

            default:
                Debug.Log("no bonus object");
                break;
        }
    }
}
