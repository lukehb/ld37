using UnityEngine;

public sealed class StarPickup : Pickup
{
    public override void ApplyPickup(Damagable player)
    {
        player.gameObject.AddComponent<Timer>();
    }

    private sealed class Timer : MonoBehaviour
    {
        private float timeRemaining = 12.0f;

        private void OnEnable()
        {
            this.gameObject.GetComponent<Damagable>().IsInvincible = true;
        }

        private void OnDisable()
        {
            this.gameObject.GetComponent<Damagable>().IsInvincible = false;
        }

        private void Update()
        {
            this.timeRemaining -= Time.deltaTime;

            if (this.timeRemaining <= 0.0f)
            {
                Component.Destroy(this);
            }
        }
    }
}
