using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeBonusObject : MonoBehaviour {

    [MenuItem("Assets/Create/Bonus Object")]
    public static void createBonusObject()
    {
        BonusObject asset = ScriptableObject.CreateInstance<BonusObject>();
        AssetDatabase.CreateAsset(asset, "Assets/NewBonusObject.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
