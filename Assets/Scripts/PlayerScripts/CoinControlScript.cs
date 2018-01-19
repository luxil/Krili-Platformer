using UnityEngine;

public class CoinControlScript : MonoBehaviour {
    private int iCoinCounter;
    public GameObject goCoinCounterText;
    public int iCoinCounterFactor = 1;

    // Use this for initialization
    void Start()
    {
        iCoinCounter = PreloadPlayerData.Instance.ICoinCount;
        updateCoinCounterText();
    }

    public void addCoins(int iNumberOfCoins)
    {
        iCoinCounter += (iNumberOfCoins * iCoinCounterFactor);
        updateCoinCounterText();
        PreloadPlayerData.Instance.ICoinCount = iCoinCounter;
        PreloadPlayerData.Instance.SavePlayerData();

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
