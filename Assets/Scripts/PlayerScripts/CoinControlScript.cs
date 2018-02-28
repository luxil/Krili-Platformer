
/**********************************************
*   This script handles the coins
**********************************************/

using UnityEngine;

public class CoinControlScript : MonoBehaviour {

    private int iCoinCounter;
    public GameObject goCoinCounterText;
    public int iCoinCounterFactor = 1;  //for example needed for DoubleCoin

    void Start()
    {
        iCoinCounter = PreloadPlayerData.Instance.ICoinCount;
        UpdateCoinCounterText();
    }

    public void AddCoins(int iNumberOfCoins)
    {
        iCoinCounter += (iNumberOfCoins * iCoinCounterFactor);
        UpdateCoinCounterText();
        PreloadPlayerData.Instance.ICoinCount = iCoinCounter;
        PreloadPlayerData.Instance.SavePlayerData();

    }

    private void UpdateCoinCounterText()
    {
        goCoinCounterText.GetComponent<UnityEngine.UI.Text>().text = iCoinCounter.ToString();
    }

    public void UpdateCoinCounterFactor(int iNewCoinCounterFactor)
    {
        iCoinCounterFactor = iNewCoinCounterFactor;
    }
}
