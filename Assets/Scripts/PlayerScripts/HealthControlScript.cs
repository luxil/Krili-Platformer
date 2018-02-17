using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControlScript : MonoBehaviour
{

    //tutorial from: https://www.youtube.com/watch?v=LsUiJItfzxU

    public GameObject[] goHearts = new GameObject[4];
    public int iHealth;
    private bool bShieldActive = false;

    // Use this for initialization
    void Start()
    {
        iHealth = 2;
        setActiveHearts();
    }

    public void addHearts(int iNumberOfHearts)
    {
        iHealth += iNumberOfHearts;
        setActiveHearts();
    }

    public void reduceHearts(int iNumberOfHearts)
    {
        if (!bShieldActive)
        {
            iHealth -= iNumberOfHearts;
            setActiveHearts();
        }
        else
        {
            deactivateShield();
        }
    }

    void setActiveHearts()
    {
        for (int i = 0; i < goHearts.Length; i++)
        {
            if (i < iHealth)
                goHearts[i].gameObject.SetActive(true);
            else
                goHearts[i].gameObject.SetActive(false);
        }
        if (iHealth < 0)
        {
            CommonGameobjects.Instance.goMenuCanvas.SetActive(true);
            CommonGameobjects.Instance.goGameOverPanel.SetActive(true);
        }
    }

    public void activateShield()
    {
        bShieldActive = true;
    }

    public void deactivateShield()
    {
        bShieldActive = false;
    }
}
