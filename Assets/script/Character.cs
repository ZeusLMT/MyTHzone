﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    public float Health;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public Animator MyAnimator { get; set; }

    public bool TakingDamage { get; set; }

    [SerializeField]
    protected GameObject throwstone;
    public bool facingRight;
    [SerializeField]
    private EdgeCollider2D KnifeAttackCol;
    [SerializeField]
    private List<string> damageSources;


    public virtual void Start()
    {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeDirection()
    {
        facingRight = !facingRight;
        //transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public virtual void ThrowStone(int value)
    {

        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(throwstone, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<weapon>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(throwstone, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<weapon>().Initialize(Vector2.left);
        }
    }

    public abstract IEnumerator TakeDamage();

    public void MeleeAttack()
    {
        KnifeAttackCol.enabled = !KnifeAttackCol.enabled;
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (damageSources.Contains(other.gameObject.tag))
        {
            StartCoroutine(TakeDamage());
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

