using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        MainMenuGOs.Instance.goEventSystem.GetComponent<MainMenuFunction>().LoadLevel(name);
    }
}
