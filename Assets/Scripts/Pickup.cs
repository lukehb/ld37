using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    private AudioClip pickupSound = null;

    public abstract void ApplyPickup(Damagable player);

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Damagable damagable = other.transform.root.GetComponent<Damagable>();
        if (damagable != null && damagable.gameObject.GetComponent<Player>() != null)
        {
            GlobalAudioSource.Instance.PlayOneShot(this.pickupSound);

            ApplyPickup(damagable);
            Destroy(this.gameObject);
        }
    }

}