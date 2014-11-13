﻿using UnityEngine;
using System.Collections;

public class HelicopterMoving : MonoBehaviour
{
    float speed = 8.0f;
	float bombSpeed = 20f;

	public bool isAttacking = true;
	float height = 10.5f;
	float safeDistanceFromTarget = 50f;
	Vector3 retreatDirection;

	GameObject projectile;

    GameObject target;

    void Start() {
		retreatDirection = new Vector3 (0, 0, 0);
        target = GameObject.FindGameObjectWithTag("Player");
		projectile = Resources.Load("Prefabs/Bullets/ennemyBullet") as GameObject;
    }

    void Update() {
        if (isAttacking) {
			attack();
		} else {
			retreat ();
		}
    }

	void attack() {
		transform.LookAt (target.transform.position + new Vector3 (0, height, 0));
		transform.position += transform.forward * speed * Time.deltaTime;
		
		if (calculateDistanceFromTarget() < height) {
			dropBomb();
			calculateRetreatDirection();
			isAttacking = false;
		}
	}

	void retreat() {
		transform.LookAt (retreatDirection);
		transform.position += transform.forward * speed * Time.deltaTime;
		
		if (calculateDistanceFromTarget() > safeDistanceFromTarget) {
			isAttacking = true;
		}
	}

	void dropBomb() {
		GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, transform.position, Quaternion.identity);
		newProjectile.transform.LookAt(target.transform.position);
		newProjectile.renderer.material.color = Color.yellow;
		newProjectile.rigidbody.velocity = (newProjectile.transform.forward * bombSpeed);

	}

	float calculateDistanceFromTarget() {
		return (target.transform.position - transform.position).magnitude;
	}

	void calculateRetreatDirection() {
		retreatDirection = transform.position + new Vector3 (Random.Range (-1000f, 1000f), 0, Random.Range (-1000f, 1000f));
	}

}
