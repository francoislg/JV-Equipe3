using UnityEngine;
using System.Collections;

public class FilletteAI : EnemyHasLife {
	protected Animator animator;
	protected GameObject target;
	protected int range = 15;
	protected float acceleration = 0.3f;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.transform.position);

		Quaternion rot = transform.rotation;
		rot.x = 0;
		transform.rotation = rot;

		if(animator){
			float distance = Vector3.Distance(transform.position, target.transform.position);
			animator.SetBool("IsInRange", distance < range);
			if(distance < range){
				rigidbody.velocity += transform.forward * acceleration;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject == target){
			rigidbody.velocity = Vector3.zero;
		}
	}

	protected override void OnDeath ()
	{
		base.OnDeath ();
		Destroy(gameObject);
	}
}
