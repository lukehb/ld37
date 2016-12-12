﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {

    /**
     * Exposed inspector fields
     **/
    [SerializeField]
    private float health = 5;

    [SerializeField]
    private DamageEffect damageEffect;

    [SerializeField]
    private ParticleSystem deathEffect;

    [SerializeField]
    private SpriteRenderer deathSplat;

    private Pickup itemDropPrefab;
    private float timeElapsed = 0;
    private bool hasDeathEffectStarted = false;
    private float maxHealth = 5;

	// Use this for initialization
	void Start () {
        this.maxHealth = health;
    }
	
	// Update is called once per frame
	void Update () {
        //check if death effect has been told to play and is done playing
		if(hasDeathEffectStarted && !deathEffect.IsAlive())
        {
            //spawn in death splat with random rotation and scale
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, Random.value * 360);
            SpriteRenderer deathSplatInst = Instantiate(deathSplat, this.transform.position, rot);
            deathSplatInst.transform.localScale =  deathSplatInst.transform.localScale + Random.onUnitSphere;
            //spawn in item drop prefab if it has one
            if(itemDropPrefab != null)
            {
                Vector3 pos = this.transform.position + Random.onUnitSphere;
                Instantiate(itemDropPrefab, pos, Quaternion.identity);
            }
            //remove this damagable from the scene
            Destroy(this.gameObject);
        }else if(hasDeathEffectStarted && deathEffect.IsAlive())
        {
            timeElapsed += Time.deltaTime;
            if (!damageEffect.IsPlaying())
            {
                damageEffect.PlayEffect();
            }
            //random scale
            Vector3 scale = this.transform.localScale;
            scale = (scale + (Random.insideUnitSphere - Random.insideUnitSphere) * 0.2f);
            this.transform.localScale = scale; 
        }
	}

    void OnTriggerEnter2D(Collider2D other){
        Damager damager = other.GetComponent<Damager>();
        if(damager != null)
        {
            damager.DealDamageTo(this);
        }
    }

    /**
     * Public stuff
     **/
    public float Health
    {
        get { return this.health; }
    }

    public void DecrementHealth(float damage)
    {
        this.health = Mathf.Max(0, this.health - damage);
        this.damageEffect.PlayEffect();
        if (health <= 0 && !this.hasDeathEffectStarted)
        {
            this.hasDeathEffectStarted = true;
            deathEffect.Play();
        }
    }

    public void RestoreHealth(float heals)
    {
        this.health = Mathf.Min(this.maxHealth, this.health + heals);
    }

    public float MaxHealth
    {
        get { return this.maxHealth;  }
    }

    public void AttachItemDrop(Pickup pickupPrefab)
    {
        this.itemDropPrefab = pickupPrefab;
    }

}
