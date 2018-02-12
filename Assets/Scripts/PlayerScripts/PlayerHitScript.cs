using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour {
    private Color colorStart;
    private Color colorHit = Color.red;
    //duration of lerp
    private float fDurationLerp = 0.2F;
    //duration of player flashing
    private float fDurationFlash = 0.7F;
    private Renderer rendPlayer;
    public bool bPlayerGotHit;
    public float fStartTime;

    // Use this for initialization
    void Start () {
        rendPlayer = GetComponent<Renderer>();
        //colorStart = rendPlayer.material.color;
        Debug.Log("there is something wrong with the color");
        bPlayerGotHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(bPlayerGotHit && fStartTime + fDurationFlash > Time.time)
        {
            float lerp = Mathf.PingPong(Time.time, fDurationLerp) / fDurationLerp;
            rendPlayer.material.color = Color.Lerp(colorStart, colorHit, lerp);
        }
        else
        {
            rendPlayer.material.color = colorStart;
            bPlayerGotHit = false;
        }
    }

    public void playerGotHurt()
    {
        bPlayerGotHit = true;
        fStartTime = Time.time;
    }
}
