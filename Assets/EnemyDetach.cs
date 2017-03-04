using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetach : MonoBehaviour {

	public GameObject projectile;




	void OnTriggerEnter2D ( Collider2D other){
		if (other.tag == "Player") {
			OnShoot ();
			Debug.Log ("enter2d");

		}

	}
	void OnTriggerExit2D ( Collider2D other )
	{
		if (other.tag == "Player") {

			Debug.Log ("exit");
		}
	}
	void OnShoot()
	{
		if (projectile != null) {
			//    var clone = Instantiate(projectile, transform.position, Quaternion.identity);
			//    Debug.Log("shoot");
			//}
			Debug.Log (" ban");
			var tmp = Instantiate (projectile, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			tmp.GetComponent<Projectile> ().Initialize (Vector2.left);

		}
	}
}