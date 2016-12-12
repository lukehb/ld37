using UnityEngine;

public sealed class HamHandsPickup : Pickup
{
    public override void ApplyPickup(Damagable player)
    {
        Transform handsTransform = player.transform.Find("Body/Hands");
        if (handsTransform != null)
        {
            handsTransform.gameObject.AddComponent<HamHandsTimer>();
        }
    }

    private sealed class HamHandsTimer : MonoBehaviour
    {
        private float timeRemaining = 8.0f;

        private void OnEnable()
        {
            this.transform.localScale += new Vector3(10.0f, 10.0f, 10.0f);

            foreach (Damager damager in this.gameObject.GetComponentsInChildren<Damager>())
            {
                damager.Damage += 5.0f;
            }
        }

        private void OnDisable()
        {
            this.transform.localScale -= new Vector3(10.0f, 10.0f, 10.0f);

            foreach (Damager damager in this.gameObject.GetComponentsInChildren<Damager>())
            {
                damager.Damage -= 5.0f;
            }
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
