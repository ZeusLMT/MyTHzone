using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabs;
	private float delay = 2.0f;
    public float delayMax;
    public float delayMin;
    public bool active = true;


	// Use this for initialization
	void Start () {
		StartCoroutine (ObjectsGenerator ());
        delay = Random.Range(delayMin, delayMax);

	}

	IEnumerator ObjectsGenerator(){

		yield return new WaitForSeconds (delay);

		if (active) {
			var newTransform = transform;

			Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position, Quaternion.identity);

		}
        delay = Random.Range(delayMin, delayMax);
        StartCoroutine (ObjectsGenerator ());

	}

}
