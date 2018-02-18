using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour {

    public Texture[] textures;
    //duration of lerp
    private float fChangeInterval = 0.1F;
    //duration of player flashing
    private float fDurationFlash = 0.7F;
    private Renderer rendPlayer;
    private bool bPlayerGotHit;
    private float fStartTime;

    // Use this for initialization
    void Start () {
        rendPlayer = GetComponent<Renderer>();
        bPlayerGotHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(bPlayerGotHit && fStartTime + fDurationFlash > Time.time)
        {
            //change texture of the player to signalize that he is hurt
            if (textures.Length == 0)
                return;
            
            int index = Mathf.FloorToInt(Time.time / fChangeInterval);
            index = index % textures.Length;
            rendPlayer.material.mainTexture = textures[index];
        }
        else
        {
            //after a time change to his normal texture
            rendPlayer.material.mainTexture = textures[0];
            bPlayerGotHit = false;
        }
    }

    public void PlayerGotHurt()
    {
        bPlayerGotHit = true;
        fStartTime = Time.time;
    }
}
