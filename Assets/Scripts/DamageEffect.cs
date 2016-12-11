using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour, IVisualEffect {

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float effectDurationSeconds = 0.1f;

    private float timeElapsed = float.MaxValue;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(timeElapsed < effectDurationSeconds)
        {
            float x = timeElapsed / effectDurationSeconds;
            //use a gaussian distribution with a mean of 0.5, height of 1, and approaching y=0 as x= 0 or 1,
            //i.e e^(-20*(x-0.5)^2)
            float alpha = Mathf.Exp(-20f * (Mathf.Pow(x - 0.5f, 2)));
            Color c = Color.white;
            c.a = alpha;
            spriteRenderer.color = c;
            timeElapsed += Time.deltaTime;

            //restore default color after effect has elapsed
            if(timeElapsed >= effectDurationSeconds)
            {
                c.a = 0;
                spriteRenderer.color = c;
            }

        }
	}

    /**
     * Public
     **/
    public void PlayEffect()
    {
        timeElapsed = 0;
    }

    public bool IsPlaying()
    {
        return timeElapsed < effectDurationSeconds;
    }

}
