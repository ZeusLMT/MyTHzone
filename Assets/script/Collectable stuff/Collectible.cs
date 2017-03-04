using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    public int AddScore;
    public int AddHP;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D target){
        if (target.gameObject.tag == "Player")
        {
            if (Player.Instance.Health <= (100 - AddHP)) Player.Instance.Health += AddHP;
            else Player.Instance.Health = 100;
            Player.Instance.Score += AddScore;
            Destroy(gameObject);
        }
	}
}
