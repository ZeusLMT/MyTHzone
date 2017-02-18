﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
	[ SerializeField]
	protected float movementSpeed;

	public bool Attack { get; set; }
	public Animator MyAnimator { get; set; }

	[ SerializeField]
	protected GameObject throwstone;
	public bool facingRight;


	public virtual void Start () {
		facingRight = true;
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeDirection(){
		facingRight = !facingRight;
		//transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	public virtual void ThrowStone (int value) {

		if(facingRight) {
			GameObject tmp = (GameObject)Instantiate (throwstone, transform.position, Quaternion.Euler (new Vector3 (0, 0, -90)));
			tmp.GetComponent<stone>().Initialize (Vector2.right);
		} else {
			GameObject tmp = (GameObject)Instantiate (throwstone, transform.position, Quaternion.Euler (new Vector3 (0, 0, 90)));
			tmp.GetComponent<stone>().Initialize (Vector2.left);
		}
	}
}

