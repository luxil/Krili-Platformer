using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControlScript : MonoBehaviour
{

    //tutorial from: https://www.youtube.com/watch?v=LsUiJItfzxU
    public GameObject[] goHearts = new GameObject[4];
    public int iHealth;
    private bool bShieldActive = false;
	
	private GameObject goGameOverPanel;
	private GameObject goMenuCanvas;

    // Use this for initialization
    void Start()
    {
        iHealth = 2;
        SetActiveHearts();
		goGameOverPanel = CommonGameobjects.Instance.goGameOverPanel;
		goMenuCanvas = CommonGameobjects.Instance.goMenuCanvas;
    }

    //add hearts
    public void AddHearts(int iNumberOfHearts)
    {
        iHealth += iNumberOfHearts;
        SetActiveHearts();
    }

    //reduce hearts
    public void ReduceHearts(int iNumberOfHearts)
    {
        if (!bShieldActive)
        {
            iHealth -= iNumberOfHearts;
            SetActiveHearts();
        }
        else
        {
            DeactivateShield();
        }
    }

    //update active hearts
    private void SetActiveHearts()
    {
        for (int i = 0; i < goHearts.Length; i++)
        {
            if (i < iHealth)
                goHearts[i].gameObject.SetActive(true);
            else
                goHearts[i].gameObject.SetActive(false);
        }
        //check whether player is dead
        if (iHealth < 0)
        {
            //player is dead
			goMenuCanvas.SetActive(true);
			goGameOverPanel.SetActive(true);
        }
    }

    public void ActivateShield()
    {
        bShieldActive = true;
    }

    public void DeactivateShield()
    {
        bShieldActive = false;
    }
}
