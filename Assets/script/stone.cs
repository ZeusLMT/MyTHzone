﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]
public class stone : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody2D myRigidbody;
	private Vector2 direction;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myRigidbody.velocity = direction * speed;
	}
	void OnBecameInvisible (){
		Destroy (gameObject);
	}
	public void Initialize (Vector2 direction){
		this.direction = direction;
	}
}
