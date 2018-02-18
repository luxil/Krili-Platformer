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
    private Button [] butArrbutton;
    private bool bActivateAllButtons = false;
    Color colOldColor;

    // Use this for initialization
    private void Awake()
    {
        ppdata = PreloadPlayerData.Instance;
        goArrBonusObjects = PreloadBonusObjectsScript.Instance.boArrBonusObjects;
        iListInventarBO = ppdata.iListInventarBO;
        butArrbutton = new Button[ppdata.IMaxBO];
        LoadInventory();
    }

    public void Start()
    {
        //ActiveShopAndButtons();
    }

    public void LoadInventory()
    {
        if (butArrbutton != null)
        {
            foreach (Button but in butArrbutton)
            {
                if (but != null)
                {
                    Destroy(but.gameObject);
                }
            }
        }
        ppdata.LoadPlayerData();
        iListInventarBO = ppdata.iListInventarBO;
        int iIndexButton = 0;
        foreach (int i in iListInventarBO)
        {
            butArrbutton[iIndexButton] = Instantiate(buInvBOButton);
            butArrbutton[iIndexButton].transform.SetParent(goInventoryBOPanel.transform);
            butArrbutton[iIndexButton].gameObject.SetActive(true);
            butArrbutton[iIndexButton].transform.localScale = new Vector3(1,1,1);
            butArrbutton[iIndexButton].GetComponent<InvBOButton>().tName.text = goArrBonusObjects[i].sBonusName;
            butArrbutton[iIndexButton].GetComponent<InvBOButton>().tDescription.text = goArrBonusObjects[i].sDescription;
            butArrbutton[iIndexButton].GetComponent<InvBOButton>().iCurrentBO = i;
            int iTempIndex = iIndexButton;
            butArrbutton[iIndexButton].GetComponent<Button>().onClick.AddListener(() => { OnClickedButton(iTempIndex);  });
            butArrbutton[iIndexButton].GetComponent<InvBOButton>().iIndexButton = iIndexButton++;
        }
    }

    void OnClickedButton(int index)
    {
        if (!butArrbutton[index].GetComponent<InvBOButton>().bSelected && PreloadBonusObjectsScript.Instance.IMaxCurrentBonusObjects> iCountSelectedBo)
        {
            colOldColor = butArrbutton[index].GetComponent<Image>().color;
            butArrbutton[index].GetComponent<Image>().color = Color.green;
            butArrbutton[index].GetComponent<InvBOButton>().bSelected = true;
            iCountSelectedBo++;
        }
        else if (butArrbutton[index].GetComponent<InvBOButton>().bSelected)
        {
            butArrbutton[index].GetComponent<Image>().color = colOldColor;
            butArrbutton[index].GetComponent<InvBOButton>().bSelected = false;
            iCountSelectedBo--;
        }
    }

    public void SetCurrentBoForLevel()
    {
        int iSelectButton = -1;
        int iSelectButton2 = -1;
        foreach (Button but in butArrbutton)
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
        LoadInventory();
        iCountSelectedBo = 0;
        this.bActivateAllButtons = bActivateAllButtons;
    }

    public void ActivateButtons()
    {
        if (butArrbutton != null)
        {
            foreach (Button but in butArrbutton)
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
