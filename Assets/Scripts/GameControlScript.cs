using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour {

    //tutorial from: https://www.youtube.com/watch?v=LsUiJItfzxU

    public GameObject[] goHearts;
    public int iHealth;

    // Use this for initialization
    void Start()
    {
        iHealth = 2;
        setActiveHearts(iHealth);
    }

    // Update is called once per frame
    void Update()
    {
        setActiveHearts(iHealth);
    }

    public void addHearts(int iNumberOfHearts)
    {
        iHealth += iNumberOfHearts;
    }

    public void reduceHearts(int iNumberOfHearts)
    {
        iHealth -= iNumberOfHearts;
    }

    void setActiveHearts(int iNumberActiveHearts)
    {
        for (int i = 0; i < goHearts.Length; i++)
        {
            if(i < iNumberActiveHearts)
                goHearts[i].gameObject.SetActive(true);
            else
                goHearts[i].gameObject.SetActive(false);
        }
    }
}
