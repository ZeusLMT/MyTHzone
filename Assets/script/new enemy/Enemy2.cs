using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
	private Animator animator;
    public AudioClip attackSound;
    public float attackDelay = 3f;
    public GameObject projectile;
    private bool readyToAttack;
    
	private int health = 30;
    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();

        if (attackDelay != 0)
        {
            StartCoroutine(OnAttack());
        }
    }

  

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        Fire();
        StartCoroutine(OnAttack());
    }

    void Fire()
    {

        animator.SetInteger("AnimState", 1);
        if (attackSound)
            AudioSource.PlayClipAtPoint(attackSound, transform.position);
    }
    void Update()
    {
        animator.SetInteger("AnimState", 0);
    }

    void OnShoot()
	{
		if (projectile != null) {
			//    var clone = Instantiate(projectile, transform.position, Quaternion.identity);
			//    Debug.Log("shoot");
			//}

			var tmp = Instantiate (projectile, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			tmp.GetComponent<Projectile> ().Initialize (Vector2.left);

		}
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "PlayerKnife" || other.gameObject.tag =="KnifeAttack") {
			Debug.Log ("Kill Enemy");
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


	/*public override IEnumerator TakeDamage(){
		yield return null;
	}*/



        /*void OnCollisionEnter2D ( Collision2D other){
        if (other.gameObject.tag == "Player")
            animator.SetTrigger ("shoot");
        OnShoot ();
        }


            /*void OnTriggerEnter2D ( Collider2D target){
            if (target.gameObject && target.gameObject.tag == "Player") {
                Debug.Log ("hihi " + readyToAttack);
                    if (readyToAttack) {

                        var explode = target.GetComponent <Explode> () as Explode;
                        explode.OnExplode ();


                    } else {
                        animator.SetInteger ("AnimState", 1);
                        Debug.Log ("else");
                    }
                }
            }

            void OnTriggerExit2D (Collider2D target){
                Debug.Log ("exit");
                readyToAttack = false;
                animator.SetInteger ("AnimState", 0);
            }

            void Attack(){
                readyToAttack = true;
                Debug.Log ("attack");
            }*/
    


			
