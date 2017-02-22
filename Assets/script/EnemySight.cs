using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight: MonoBehaviour {
	[SerializeField]
	private EnemyFollowTarget enemy;

	 
		

	void OnTriggerEnter2D ( Collider2D other){
		if (other.tag == "Player") {
			enemy.Target = other.gameObject;
			Debug.Log ("enter2d");
		}

	}
	void OnTriggerExit2D ( Collider2D other )
	{
		if (other.tag == "Player") {
			enemy.Target = null;
			Debug.Log ("exit");
		}
	}
}
