using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
	
	private static Player instance;

	public static Player Instance {
		get { 
			if (instance == null) {
				instance = GameObject.FindObjectOfType <Player> ();
			}
			return instance;
		}
	}



	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask WhatIsGround;
	//private bool IsGrounded;
	//private bool jump;
	[SerializeField]
	private float jumpForce = 200;
	[SerializeField]
	private bool airControl;
	[SerializeField]
	public float forwardSpeed = 20;
	//private bool jumpAttack;

	//private InputState inputState;
	public Rigidbody2D MyRigidbody { get; set; }



	public bool Jump { get; set; }

	public bool Slide { get; set; }
	[SerializeField]
	public bool OnGround { get; set; }

	public override void Start ()
	{
		base.Start ();
		MyRigidbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		HanldeInput ();

	}


	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		OnGround = IsGrounded () && !MyAnimator.GetCurrentAnimatorStateInfo(0).IsTag("JumpUp");
		HandleMovement (horizontal);
		Flip (horizontal);
		//HandleAttacks ();
		HandleLayers ();
		//ResetValue ();
	}


	private void HandleMovement (float horizontal)
	{
		if (MyRigidbody.velocity.y < 0) {
			MyAnimator.SetBool ("land", true);
		}
		if (!Attack && !Slide && (OnGround || airControl)) {
			MyRigidbody.velocity = new Vector2 (horizontal * movementSpeed, MyRigidbody.velocity.y);
		}

		if (OnGround && Jump) {
			
			if (this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("idle")) {
				MyRigidbody.velocity = (new Vector2 (0, 50 * (jumpForce / MyRigidbody.mass)));
			} else if (this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("run")) {
				MyRigidbody.velocity = (new Vector2 (horizontal * movementSpeed, 50 * (jumpForce / MyRigidbody.mass)));
			} 
		}
		MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));



		/*if (myRidgidbody.velocity.y < 0)
			myAnimator.SetBool ("land", true);
		if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack") && (IsGrounded ||airControl)) {
			myRidgidbody.velocity = new Vector2 (horizontal*movementSpeed, myRidgidbody.velocity.y);	
			//Debug.Log (IsGrounded);
		}
		if (IsGrounded && jump) {

			myAnimator.SetTrigger ("jump");

			if (this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("idle")) {
				myRidgidbody.velocity = (new Vector2 (0, 50 * (jumpForce / myRidgidbody.mass)));
			} else if (this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("run") || jumpAttack) {
				myRidgidbody.velocity = (new Vector2 (horizontal * movementSpeed, 50 * (jumpForce / myRidgidbody.mass)));
			} 
		}
	

		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Slide")) {
			myAnimator.SetTrigger ("slide");

		///} else if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag("Slide")) {
		///	myAnimator.SetBool ("slide", false);
		}
		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));// link run mode with idle mode
		///Debug.Log (Mathf.Abs (horizontal));*/
	}



	/*private void HandleAttacks(){
		
		if (attack && IsGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
			myAnimator.SetTrigger ("attack");
			myRidgidbody.velocity = Vector2.zero;
		}
		if (jumpAttack && !IsGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo (1).IsName ("Jump_Attack")){
			myAnimator.SetBool ("jumpAttack", true);
		}
		if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo (1).IsName ("Jump_Attack")) {
			myAnimator.SetBool ("jumpAttack", false);
		}
	}*/

	private void HanldeInput ()
	{
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			MyAnimator.SetTrigger ("slide");
			/*attack = true;
			jumpAttack = true;*/
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			MyAnimator.SetTrigger ("jump");
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			MyAnimator.SetTrigger ("attack");
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			MyAnimator.SetTrigger ("throw");

		}
	}

	private void Flip (float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			ChangeDirection ();

		}
	}
	/*private void ResetValue(){
		attack = false;
		slide = false;
		jump = false;
		jumpAttack = false;
	} */
	private bool IsGrounded ()
	{
		if (MyRigidbody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, WhatIsGround);
			
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						/*myAnimator.ResetTrigger ("jump");
						myAnimator.SetBool ("land", false);*/
						return true;
					}
				}
			}
		}
		return false;


	}

	private void HandleLayers ()
	{
		if (!OnGround)
			MyAnimator.SetLayerWeight (1, 1);
		else
			MyAnimator.SetLayerWeight (1, 0);
	}
	public override void ThrowStone ( int value){
		if (!OnGround && value == 1 || OnGround && value == 0) {
			base.ThrowStone (value);
		}
	}
}
