using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
[RequireComponent (typeof (Animator))]
public class Player : MonoBehaviour {

	private const string MoveHorizontalBtn = "Move Horizontal";
	private const string MoveVerticalBtn = "Move Vertical";
	private const string AttackBtn = "Attack";
	private static readonly int PunchingAnimationId = Animator.StringToHash ("Punching");

	/**
	 * Fields
	 **/
	private Animator anim;

	/**
	 * Player stats to tweak
	 **/
	[SerializeField]
	private GameObject Body;

	[SerializeField]
	private float Speed = 10;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		BodyPartsFaceMouse ();
		HandleInput ();
	}

	void BodyPartsFaceMouse(){
		Vector3 screenMousePos = Input.mousePosition;
		screenMousePos.z = -Camera.main.transform.position.z;
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (screenMousePos);
		Vector3 dirToFace = (worldMousePos - this.transform.position).normalized;
		Body.transform.up = dirToFace;
	}

	void HandleInput(){
		if(Input.GetButton(MoveHorizontalBtn)){
			bool isLeft = Input.GetAxisRaw (MoveHorizontalBtn) < 0;
			float scaledSpeed = (isLeft ? -Speed : Speed) * Time.deltaTime;
			Vector3 displacement = this.transform.right * scaledSpeed;
			transform.Translate (displacement, Space.World);
		}
		if(Input.GetButton(MoveVerticalBtn)){
			bool isDown = Input.GetAxisRaw (MoveVerticalBtn) < 0; 
			float scaledSpeed = (isDown ? -Speed : Speed) * Time.deltaTime;
			Vector3 displacement = this.transform.up * scaledSpeed;
			transform.Translate (displacement, Space.World);
		}
		if(Input.GetButtonDown(AttackBtn)){
			anim.SetTrigger(PunchingAnimationId);
		}
	}

}
