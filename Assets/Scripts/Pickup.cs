using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public abstract void ApplyPickup(Damagable player);

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Damagable damagable = other.transform.root.GetComponent<Damagable>();
        if (damagable != null)
        {
            ApplyPickup(damagable);
            Destroy(this.gameObject);
        }
    }

}