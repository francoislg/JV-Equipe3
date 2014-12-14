using UnityEngine;
using System.Collections;

public class FilletteAI : EnemyHasLife {
	protected Animator animator;
	protected GameObject target;
	protected int range = 15;
	protected float acceleration = 0.3f;

	// Use this for initialization
	protected override void OnStart () {
		animator = GetComponentInChildren<Animator>();
		target = GameObject.FindGameObjectWithTag("Player");
		rigidbody.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	protected override void OnUpdate () {
		base.OnUpdate();
		transform.LookAt(target.transform.position);

		if(animator){
			if(animator.GetBool("IsInRange")){
				rigidbody.velocity += transform.forward * acceleration;
			}else{
				float distance = Vector3.Distance(transform.position, target.transform.position);
				if(distance < range){
					animator.SetBool("IsInRange", true);
				}
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.tag != "Player"){
			Physics.IgnoreCollision(other.collider, collider);
		}
		rigidbody.velocity = Vector3.zero;
	}

	protected override void OnDeath ()
	{
		base.OnDeath ();
		Destroy(gameObject);
	}
}
