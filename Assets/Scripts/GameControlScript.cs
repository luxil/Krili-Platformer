using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour {

    //tutorial from: https://www.youtube.com/watch?v=LsUiJItfzxU

    public GameObject[] hearts;
    public int health;

    // Use this for initialization
    void Start()
    {
        health = 2;
        setActiveHearts(health);
    }

    // Update is called once per frame
    void Update()
    {
        setActiveHearts(health);
    }

    public void addHearts(int numberOfHearts)
    {
        health += numberOfHearts;
    }

    public void reduceHearts(int numberOfHearts)
    {
        health -= numberOfHearts;
    }

    void setActiveHearts(int numberActiveHearts)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < numberActiveHearts)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
    }
}
