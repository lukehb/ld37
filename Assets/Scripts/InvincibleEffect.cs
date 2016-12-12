using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleEffect : MonoBehaviour, IVisualEffect {

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float effectDurationSeconds = 0.1f;

    private float timeElapsed = float.MaxValue;

    private bool isPlaying = false;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float time = Mathf.Abs(Time.time % (effectDurationSeconds * 2.0f) - effectDurationSeconds);

        float x = this.isPlaying ? time / effectDurationSeconds : 0.0f;
        //use a gaussian distribution with a mean of 0.5, height of 1, and approaching y=0 as x= 0 or 1,
        //i.e e^(-20*(x-0.5)^2)
        float alpha = Mathf.Exp(-20f * (Mathf.Pow(x - 0.5f, 2)));
        Color c = Color.yellow;
        c.a = alpha;
        spriteRenderer.color = c;
	}

    /**
     * Public
     **/
    public void PlayEffect()
    {
        this.isPlaying = true;
    }

    public void StopEffect()
    {
        this.isPlaying = false;
    }

    public bool IsPlaying()
    {
        return this.isPlaying;
    }

}
