using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControlScript : MonoBehaviour {
    private int iCoinCounter;
    public GameObject goCoinCounterText;
    public int iCoinCounterFactor = 1;

    // Use this for initialization
    void Start()
    {
        iCoinCounter = 0;
        updateCoinCounterText();
    }

    public void addCoin(int iNumberOfCoins)
    {
        iCoinCounter += (iNumberOfCoins * iCoinCounterFactor);
        updateCoinCounterText();

    }

    private void updateCoinCounterText()
    {
        goCoinCounterText.GetComponent<UnityEngine.UI.Text>().text = iCoinCounter.ToString();
    }

    public void updateCoinCounterFactor(int iNewCoinCounterFactor)
    {
        iCoinCounterFactor = iNewCoinCounterFactor;
    }
}
