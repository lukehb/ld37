using UnityEngine;

public sealed class HamHandsPickup : Pickup
{
    public override void ApplyPickup(Damagable player)
    {
        Transform handsTransform = player.transform.Find("Body/Hands");
        if (handsTransform != null)
        {
            handsTransform.gameObject.AddComponent<Timer>();
        }
    }

    private sealed class Timer : MonoBehaviour
    {
        private float timeRemaining = 25.0f;

        private void OnEnable()
        {
            this.transform.localScale += new Vector3(10.0f, 10.0f, 10.0f);
        }

        private void OnDisable()
        {
            this.transform.localScale -= new Vector3(10.0f, 10.0f, 10.0f);
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
