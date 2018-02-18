using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {

    private PreloadPlayerData ppdata;
    public GameObject goInventoryBOPanel;
    public GameObject goShopCanvas;
    public Button buInvBOButton;
    public int iCountSelectedBo = 0;

    private BonusObject[] goArrBonusObjects;
    private List<int> iListInventarBO;
    private Button [] button;
    private bool bActivateAllButtons = false;
    Color colOldColor;

    // Use this for initialization
    private void Awake()
    {
        ppdata = PreloadPlayerData.Instance;
        goArrBonusObjects = PreloadBonusObjectsScript.Instance.boArrBonusObjects;
        iListInventarBO = ppdata.iListInventarBO;
        button = new Button[ppdata.IMaxBO];
        LoadInventory();
    }

    public void Start()
    {
        //ActiveShopAndButtons();
    }

    public void LoadInventory()
    {
        int iIndexButton = 0;
        foreach (int i in iListInventarBO)
        {
            button[iIndexButton] = Instantiate(buInvBOButton);
            button[iIndexButton].transform.SetParent(goInventoryBOPanel.transform);
            button[iIndexButton].gameObject.SetActive(true);
            button[iIndexButton].transform.localScale = new Vector3(1,1,1);
            button[iIndexButton].GetComponent<InvBOButton>().tName.text = goArrBonusObjects[i].sBonusName;
            button[iIndexButton].GetComponent<InvBOButton>().tDescription.text = goArrBonusObjects[i].sDescription;
            button[iIndexButton].GetComponent<InvBOButton>().iCurrentBO = i;
            int iTempIndex = iIndexButton;
            button[iIndexButton].GetComponent<Button>().onClick.AddListener(() => { OnClickedButton(iTempIndex);  });
            button[iIndexButton].GetComponent<InvBOButton>().iIndexButton = iIndexButton++;
        }
    }

    void OnClickedButton(int index)
    {
        if (!button[index].GetComponent<InvBOButton>().bSelected && PreloadBonusObjectsScript.Instance.IMaxCurrentBonusObjects> iCountSelectedBo)
        {
            colOldColor = button[index].GetComponent<Image>().color;
            button[index].GetComponent<Image>().color = Color.green;
            button[index].GetComponent<InvBOButton>().bSelected = true;
            iCountSelectedBo++;
        }
        else if (button[index].GetComponent<InvBOButton>().bSelected)
        {
            button[index].GetComponent<Image>().color = colOldColor;
            button[index].GetComponent<InvBOButton>().bSelected = false;
            iCountSelectedBo--;
        }
    }

    public void SetCurrentBoForLevel()
    {
        int iSelectButton = -1;
        int iSelectButton2 = -1;
        foreach (Button but in button)
        {
            if(but != null && but.GetComponent<InvBOButton>().bSelected && iSelectButton==-1)
            {
                iSelectButton = but.GetComponent<InvBOButton>().iCurrentBO;
            }
            else if (but != null && but.GetComponent<InvBOButton>().bSelected && iSelectButton2 == -1)
            {
                iSelectButton2 = but.GetComponent<InvBOButton>().iCurrentBO;
            }
        }
        PreloadBonusObjectsScript.Instance.ICurrentBonusObject = iSelectButton;
        PreloadBonusObjectsScript.Instance.ICurrentBonusObject2 = iSelectButton2;

    }

    public void SetBoolActivateAllButtons(bool bActivateAllButtons)
    {
        this.bActivateAllButtons = bActivateAllButtons;
    }

    public void ActivateButtons()
    {
        if (button != null)
        {
            foreach (Button but in button)
            {
                if (but != null)
                {
                    but.interactable = bActivateAllButtons;
                }
            }
        }
    }

    public void ActivateShopCanvas()
    {
        goShopCanvas.SetActive(!bActivateAllButtons);
    }
}
