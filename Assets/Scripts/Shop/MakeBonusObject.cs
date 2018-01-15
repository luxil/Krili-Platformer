using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeBonusObject : MonoBehaviour {

    [MenuItem("Assets/Create/Bonus Object")]
    public static void createBonusObject()
    {
        x2Object asset = ScriptableObject.CreateInstance<x2Object>();
        AssetDatabase.CreateAsset(asset, "Assets/NewBonusObject.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
