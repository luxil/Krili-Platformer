
/**********************************************
*   This script handles the level selection
**********************************************/

using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        MainMenuGOs.Instance.goEventSystem.GetComponent<MainMenuFunction>().LoadLevel(name);
    }
}
