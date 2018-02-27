
/**********************************************
*   script to handle saving and loading of player data (for example coins)
**********************************************/


using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PreloadPlayerData : MonoBehaviour
{
    private static PreloadPlayerData instance;  //instance variable
    private int iCoinCount = 0; //number of coins the player has
    public List<int> iListInventarBO = new List<int>(); //save all current BonusObjects of the player in the iListInventarBO list
    private int iMaxBO = 6; //max BonusObjects a player can have


    void Awake()
    {
        //*start set instance
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        //Keep the PreloadBonusObjectsScript even if loading level.
        DontDestroyOnLoad(this.gameObject);
        instance = this;
        //*end set instance

        LoadPlayerData();

        //tests
        if (iListInventarBO.Count < 0)
        {
            iListInventarBO = new List<int>();
            SavePlayerData();

            foreach (int test in iListInventarBO)
            {
                Debug.Log("List: " + test);
            }
        }
    }

    public static PreloadPlayerData Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<PreloadPlayerData>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No PreloadPlayerData found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }

    public int ICoinCount
    {
        get
        {
            return iCoinCount;
        }

        set
        {
            iCoinCount = value;
        }
    }

    public int IMaxBO
    {
        get
        {
            return iMaxBO;
        }
    }

    public void SavePlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");

        PlayerData data = new PlayerData();
        data.iCoinCount = ICoinCount;
        data.iListInventarBO = iListInventarBO;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadPlayerData()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            ICoinCount = data.iCoinCount;
            iListInventarBO = data.iListInventarBO;
        }
    }

    public void RemoveFromIvList(int iObject)
    {
        if (iListInventarBO.Count > 0)
        {
            var index = iListInventarBO.FindIndex(i => i == iObject); // like Where/Single
            // ensure item found
            if (index >= 0)
            {   
                iListInventarBO.RemoveAt(index);
            }
        }
    }
}

[System.Serializable]
class PlayerData
{
    public int iCoinCount;
    public List<int> iListInventarBO;
}

