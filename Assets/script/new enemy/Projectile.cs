using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	/*float speed;
	Vector2 _direction;
	bool isReady;
	// set default values in Awake function
	void Awake(){
		speed = 10f;
		isReady = false;

	}*/
	// Use this for initialization
	void Start () {
		
	}
	// function to set the bullet's direction
	/*public void SetDirection ( Vector2 direction){
		_direction = direction.normalized;
		isReady = true;
	}*/
	// Update is called once per frame
	void Update () {
		/*if (isReady) {
			Vector2 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
			    (transform.position.y < min.y) || (transform.position.y > max.y)) {
				Destroy (gameObject);
			}
		}*/
		
	}


	void OnCollisionEnter2D ( Collision2D target){
		Destroy (gameObject);
	}
}
