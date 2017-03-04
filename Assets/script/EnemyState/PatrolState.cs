using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

	private float patrolTimer;
	private float patrolDuration = 5;
	private EnemyFollowTarget enemy;



	public void Execute (){
		
		Patrol ();
		enemy.Move ();
		if ( enemy.Target != null){
			enemy.ChangeState ( new RangeState());
		}
	}
	public void Enter (EnemyFollowTarget enemy){
		this.enemy = enemy;
	}
	public void Exit (){

	}
	public void OnTriggerEnter (Collider2D other){
		
		if (other.tag == "Edge") {
			
			enemy.ChangeDirection ();

		}
	}
	private void Patrol(){
		
		patrolTimer += Time.deltaTime;
		if (patrolTimer >= patrolDuration) {
			enemy.ChangeState (new IdleState ());

		}
	}

}
  