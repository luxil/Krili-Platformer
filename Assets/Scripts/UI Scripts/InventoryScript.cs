using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour {
    PreloadPlayerData ppdata;

    public GameObject goInventoryBOPanel;
    public Button buInvBOButton;

    private BonusObject[] goArrBonusObjects;
    private List<int> iListInventarBO;
    private Button [] button;
    private Text tName;
    private Text tDescription;

    // Use this for initialization
    private void Start()
    {
        ppdata = PreloadPlayerData.Instance;
        goArrBonusObjects = PreloadBonusObjectsScript.Instance.boArrBonusObjects;
        iListInventarBO = ppdata.iListInventarBO;
        button = new Button[ppdata.IMaxBO];
        LoadInventory();
    }

    public void LoadInventory()
    {
        foreach (int test in ppdata.iListInventarBO)
        {
            Debug.Log("List: " + test);
        }

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
            //button[iIndexButton].onClick.AddListener(OnClickedButton);
            int test = iIndexButton;
            button[iIndexButton].GetComponent<Button>().onClick.AddListener(() => { OnClickedButton(test);  });
            //button[iIndexButton].GetComponent<Button>().onClick.AddListener(() => { Debug.Log("o"); });
            button[iIndexButton].GetComponent<InvBOButton>().iIndexButton = iIndexButton++;
        }
    }

    void OnClickedButton(int index)
    {
        //Debug.Log("index: " + button[index].GetComponent<InvBOButton>().iIndexButton);

        button[index].GetComponent<Image>().color = Color.red;
    }
}
