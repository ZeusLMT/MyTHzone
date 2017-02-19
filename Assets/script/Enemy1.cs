using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Character
{
	private IEnemyState currentState;
	[SerializeField]
	public GameObject Target { get; set; }
	[SerializeField]
	public bool TouchEdge;

	// Use this for initialization
	public override void Start ()
	{
		base.Start ();

		ChangeState (new IdleState ()); 
	}


	void Update ()
	{
		currentState.Execute ();
		LookAtTarget ();
	}
	private void LookAtTarget (){
		
		if (Target != null) {
			float xDir = Target.transform.position.x - transform.position.x;
			Debug.Log ("Hello" + facingRight);
			Debug.Log (xDir);
			if (xDir < 0 && facingRight || xDir > 0 && !facingRight) {
				Debug.Log ("Change direction get called");
				ChangeDirection ();
			}
		} 
		
	}


	public void ChangeState (IEnemyState newState)
	{
		Debug.Log ("Change state");
		if (currentState != null) {
			//Debug.Log ("Really exit here" + currentState);
			currentState.Exit ();
		}
		currentState = newState;
		currentState.Enter (this);
	}

	public void Move ()
	{
		if (!Attack) {
			MyAnimator.SetFloat ("speed", 1);
			transform.Translate (GetDirection () * (movementSpeed * Time.deltaTime),Space.World);
		}
	}


	public Vector2 GetDirection ()
	{
		return facingRight ? Vector2.right : Vector2.left;

	}
	void OnTriggerEnter2D ( Collider2D other){
		
		currentState.OnTriggerEnter (other);

	}

}
