using UnityEngine;

public sealed class ChargingEnemy : Enemy
{
    [SerializeField]
    private float chargeSpeed = 10.0f;

    private Vector3? chargeTarget = null;
    private float chargeDelay = 3.0f;

    public bool IsCharging
    {
        get
        {
            return this.chargeTarget != null;
        }
    }

    protected override void Attack()
    {
        if (!this.IsCharging)
        {
            if (this.chargeDelay > 0.0f)
            {
                this.chargeDelay -= Time.deltaTime;
            }

            if (this.chargeDelay <= 0.0f && Random.value < Time.deltaTime * 0.3f)
            {
                this.chargeTarget = this.Target.transform.position;

                this.chargeDelay = 0.5f;
            }
        }

        base.Attack();
    }

    protected override void Move()
    {
        if (this.IsCharging)
        {
            if (this.chargeDelay > 0.0f)
            {
                this.chargeDelay -= Time.deltaTime;
            }

            if (this.chargeDelay <= 0.0f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, this.chargeTarget.Value, this.chargeSpeed * Time.deltaTime);
            }

            if ((this.transform.position - this.chargeTarget.Value).sqrMagnitude <= 0.1f * 0.1f)
            {
                this.chargeTarget = null;

                this.chargeDelay = 3.0f;
            }
        }
        else
        {
            base.Move();
        }
    }

    protected override void Turn()
    {
        if (this.IsCharging)
        {
            Vector3 targetDisplacement = this.chargeTarget.Value - this.transform.position;

            targetDisplacement.z = 0.0f;

            this.transform.up = Vector3.RotateTowards(this.transform.up, targetDisplacement, Mathf.Deg2Rad * 180.0f * Time.deltaTime, 0.0f);
        }
        else
        {
            base.Turn();
        }
    }
}
