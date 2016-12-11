using System.Collections;
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

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other){
        Damager damager = other.GetComponent<Damager>();
        if(damager != null && damager.enabled)
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
        this.health = Mathf.Min(0, this.health - damage);
        this.damageEffect.PlayEffect();
        if (health <= 0)
        {
            //DoDeathEffect();
        }
    }


}
