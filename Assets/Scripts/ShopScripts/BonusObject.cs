﻿
/**********************************************
*   This script contains all the information a bonusobject should have. 
*   Bonusobjects are stored in the Assets/Bonusobjects.
**********************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BonusObject : ScriptableObject {
    public string sBonusName = "bonus name here";
    public int iCost = 1;
    public int iID = 0;
    public float fDuration = 5;
    public string sDescription;
    public Sprite sprite;

}
