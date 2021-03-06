﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D body2D;
	protected int health =30;
	private Animator animator;
	//private Explode explode;
    //private bool facingRight = false;
	// Use this for initialization
	void Start () {
		body2D = GetComponent < Rigidbody2D> ();
		animator = GetComponent<Animator>();
		//explode= GameObject.Find ("Player").GetComponent< Explode >();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsTag("Walking"))
        {
            body2D.velocity = new Vector2(transform.localScale.x, 0) * speed;
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerKnife" || other.gameObject.tag == "KnifeAttack")
        {
            Debug.Log("Kill Enemy");
            health -= 10;
            Destroy(other.gameObject);
            if (health > 0)
            {
                animator.SetTrigger("damage");
            }
            else
            {
                animator.SetTrigger("die");
                Destroy(gameObject, 2);
            }
        }
        /*else if (other.gameObject.tag == "Player")
        {
            Debug.Log("chetne");
            explode.OnExplode();
        }*/
    }
}
