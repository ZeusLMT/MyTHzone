using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D body2D;
	protected int health =30;
	private Animator animator;
	// Use this for initialization
	void Start () {
		body2D = GetComponent < Rigidbody2D> ();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		body2D.velocity = new Vector2 (transform.localScale.x, 0) * speed;
	}
	 void OnCollisionEnter2D ( Collision2D other){
		if (other.gameObject.tag == "PlayerKnife" || other.gameObject.tag =="KnifeAttack") {
			Debug.Log ("Kill Enemy1");
			health -= 10;
			Destroy (other.gameObject);
			if (health > 0) {
				animator.SetTrigger ("damage");
			} else {
				animator.SetTrigger ("die");
				Destroy (gameObject, 2);
			}
		}
	}
}
