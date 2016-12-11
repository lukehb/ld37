using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Enemy always slowly turns to face players.
 * Enemy always slowly walks toward the player
 * 
 **/

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private Animator anim;

    private static readonly int IsPunchingTriggerId = Animator.StringToHash("IsPunching");
    private static readonly string AttackingStateTag = "Attacking";

    private Player player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            SlowlyFacePlayer();
            SlowlyWalkTowardsPlayer();
            TryAttack();
        }
	}

    private void TryAttack()
    {
        double dist = Vector3.Distance(player.transform.position, this.transform.position);
        if(dist <= attackRadius)
        {
            AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            bool curIsAttacking = stateInfo.IsTag(AttackingStateTag);
            if (!curIsAttacking)
            {
                anim.SetTrigger(IsPunchingTriggerId);
            }
        }
    }

    private void SlowlyWalkTowardsPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void SlowlyFacePlayer()
    {
        Vector3 targetDir = player.transform.position - this.transform.position;
        float step = Time.deltaTime * turnSpeed;
        Vector3 newDir = Vector3.RotateTowards(transform.up, targetDir, step, 0.0F);
        newDir.z = 0;
        this.transform.up = newDir;
    }
 
    public void GoKillThisGuy(Player player)
    {
        this.player = player;
    }

}
