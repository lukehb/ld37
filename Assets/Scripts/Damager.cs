using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    private IVisualEffect screenShakeEffect;

    /**
     * Inspector exposed
     **/
     [SerializeField]
     private float damage = 1;

    public float Damage
    {
        get
        {
            return this.damage;
        }

        set
        {
            this.damage = value;
        }
    }

	// Use this for initialization
	void Start () {
        this.screenShakeEffect = Camera.main.GetComponent<ScreenShakeEffect>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /**
     * Public methods
     **/

    public void DealDamageTo(Damagable damagable)
    {
        this.screenShakeEffect.PlayEffect();
        damagable.DecrementHealth(this.damage);
    }

}
