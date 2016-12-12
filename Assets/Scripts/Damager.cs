﻿using System.Collections;
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

    [SerializeField]
    private bool applyDamage = false;

    public bool ApplyDamage
    {
        get
        {
            return this.applyDamage;
        }

        set
        {
            this.applyDamage = value;
        }
    }

    /**
     * Public methods
     **/

    public void DealDamageTo(Damagable damagable)
    {
        if (this.ApplyDamage)
        {
            if (this.screenShakeEffect == null)
            {
                this.screenShakeEffect = Camera.main.GetComponent<ScreenShakeEffect>();
            }

            this.screenShakeEffect.PlayEffect();
            damagable.DecrementHealth(this.damage);

            this.ApplyDamage = false;
        }
    }

}
