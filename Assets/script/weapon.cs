using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class weapon : MonoBehaviour {

	[SerializeField]
	protected float speed;
	protected Rigidbody2D myRigidbody;
	protected Vector2 direction;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

	}

	
	// Update is called once per frame
	void FixedUpdate () {
		myRigidbody.velocity = direction * speed;
		Debug.Log ("speed");

	}
	void OnBecameInvisible (){
		Destroy (gameObject);
		Debug.Log ("visible");

	}
	public void Initialize (Vector2 direction){
		this.direction = direction;
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.name == "Enemy2") {
			Destroy (gameObject);
		}
	}
}