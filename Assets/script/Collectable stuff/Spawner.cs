using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 2.0f;
	public bool active = true;


	// Use this for initialization
	void Start () {
		StartCoroutine (ObjectsGenerator ());
        delay = Random.Range(30, 35);

	}

	IEnumerator ObjectsGenerator(){

		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;

			Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);

		}

		StartCoroutine (ObjectsGenerator ());

	}

}
