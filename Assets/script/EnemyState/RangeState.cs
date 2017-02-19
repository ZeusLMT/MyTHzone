using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeState : IEnemyState {
	private Enemy1 enemy;
	private float throwTimer;
	private float throwCoolDown =3;
	private bool canAttack = true;
	//private Collision2D Ho;

	public void Execute (){
		if (enemy.Target != null) {
			enemy.TouchEdge = false;
			enemy.Move ();
		} else {
			enemy.ChangeState (new IdleState ());
		}
		enemyAttack ();
	} 

	public void Enter (Enemy1 enemy){
		this.enemy = enemy; 
	}

	public void Exit (){

	}

	public void OnTriggerEnter (Collider2D other){
	}
	private void enemyAttack(){
		throwTimer += Time.deltaTime;
		if (throwTimer >= throwCoolDown) {
			canAttack = true;
			throwTimer = 0;
		}
		if (canAttack) {
			canAttack = false;
			enemy.MyAnimator.SetTrigger ("throw");
		}
	}
}
