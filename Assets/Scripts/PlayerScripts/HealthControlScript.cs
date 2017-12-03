using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControlScript : MonoBehaviour
{

    //tutorial from: https://www.youtube.com/watch?v=LsUiJItfzxU

    public GameObject[] goHearts = new GameObject[4];
    public int iHealth;

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
        iHealth -= iNumberOfHearts;
        setActiveHearts();
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
    }
}
