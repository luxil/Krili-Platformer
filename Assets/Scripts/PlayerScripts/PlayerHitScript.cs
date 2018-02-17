using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitScript : MonoBehaviour {
    public Texture[] textures;
    //duration of lerp
    private float changeInterval = 0.1F;
    //duration of player flashing
    private float fDurationFlash = 0.7F;
    private Renderer rendPlayer;
    public bool bPlayerGotHit;
    public float fStartTime;

    // Use this for initialization
    void Start () {
        rendPlayer = GetComponent<Renderer>();
        bPlayerGotHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(bPlayerGotHit && fStartTime + fDurationFlash > Time.time)
        {
            if (textures.Length == 0)
                return;

            int index = Mathf.FloorToInt(Time.time / changeInterval);
            index = index % textures.Length;
            rendPlayer.material.mainTexture = textures[index];
        }
        else
        {
            rendPlayer.material.mainTexture = textures[0];
            bPlayerGotHit = false;
        }
    }

    public void playerGotHurt()
    {
        bPlayerGotHit = true;
        fStartTime = Time.time;
    }
}
