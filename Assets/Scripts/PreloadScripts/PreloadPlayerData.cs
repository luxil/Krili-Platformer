using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PreloadPlayerData : MonoBehaviour
{
    public static PreloadPlayerData instance;
    private int iCoinCount = 5;

    void Awake()
    {
        //SaveCoinCount();
        instance = this;
        LoadCoinCount();
        iCoinCount++;
        Debug.Log(iCoinCount);
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

    public void SaveCoinCount()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");

        PlayerData data = new PlayerData();
        data.iCoinCount = ICoinCount;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadCoinCount()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            ICoinCount = data.iCoinCount;
        }
    }
}

[System.Serializable]
class PlayerData
{
    public int iCoinCount;
}

