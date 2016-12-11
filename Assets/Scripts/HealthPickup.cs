using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup {

    [SerializeField]
    private float healthRestoreAmount = 10;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void ApplyPickup(Damagable damagable)
    {
        damagable.RestoreHealth(healthRestoreAmount);
    }
}
