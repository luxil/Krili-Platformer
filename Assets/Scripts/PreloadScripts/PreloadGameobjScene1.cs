using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreloadGameobjScene1 : MonoBehaviour {
    private static PreloadGameobjScene1 instance;
    public GameObject goPauseMenu;
    public int test = 2;

    void Awake()
    {
        //*set instance
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        //Keep the PreloadGameobjScene1 even if loading level.
        DontDestroyOnLoad(this.gameObject);
        instance = this;
        //*end set instance
    }

    public static PreloadGameobjScene1 Instance
    {
        get
        {
            if (null == instance)
            {
                instance = FindObjectOfType<PreloadGameobjScene1>();
                if (instance == null)
                {
                    throw new System.ApplicationException("No PreloadGameobjScene1 found so no instance can be accessed.");
                }
            }
            return instance;
        }
    }
}
