using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {
	
	private Rigidbody2D myRidgidbody;
	private Animator myAnimator;
	[ SerializeField]
	private float movementSpeed;
	private bool attack;
	[SerializeField]
	private bool slide;
	private bool facingRight;
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask WhatIsGround;
	private bool IsGrounded;
	private bool jump;
	[SerializeField]
	private float jumpForce = 200;
	[SerializeField]
	private bool airControl;
	private float AbsVelY;
	public float forwardSpeed = 20;

	//private InputState inputState;


	void Start () {
		facingRight = true;
		myRidgidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update(){
		HanldeInput ();

	}
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		IsGrounded = OnGrounded ();
		HandleMovement (horizontal);
		Flip (horizontal);
		HandleAttacks ();
		ResetValue ();
	}
	private void HandleMovement(float horizontal){
		if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack") && (IsGrounded ||airControl)) {
			myRidgidbody.velocity = new Vector2 (horizontal*movementSpeed, myRidgidbody.velocity.y);	
			//Debug.Log (IsGrounded);
		}
		if (IsGrounded && jump) {
			if (this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("idle")) {
				myRidgidbody.velocity = (new Vector2 (0, 50 * (jumpForce / myRidgidbody.mass)));
			} else if (this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("run")) {
				myRidgidbody.velocity = (new Vector2 (horizontal * movementSpeed, 50 * (jumpForce / myRidgidbody.mass)));
			}

		}

		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Slide")) {
			myAnimator.SetTrigger ("slide");

		///} else if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag("Slide")) {
		//	myAnimator.SetBool ("slide", false);
		}
		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));// link run mode with idle mode
		//Debug.Log (Mathf.Abs (horizontal));
	}



	private void HandleAttacks(){
		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
			myAnimator.SetTrigger ("attack");
			myRidgidbody.velocity = Vector2.zero;
		}
	}

	private void HanldeInput(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			attack = true;
		}
		if (Input.GetKeyDown (KeyCode.Space) && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("idle")) {
			slide = true;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			jump = true;
		}
	}
	private void Flip(float horizontal){
		if (horizontal > 0 &&!facingRight|| horizontal <0 &&facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;

		}
	}
	private void ResetValue(){
		attack = false;
		slide = false;
		jump = false;
	}
	private bool OnGrounded(){
		if (myRidgidbody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, WhatIsGround);
			
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;
					}
				}
			}
		}
		return false;

		/*AbsVelY = System.Math.Abs (myRidgidbody.velocity.y);
		if (AbsVelY <= 3)
			return true;
		else
			return false;
	}*/




	/*void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}*/



}
}
