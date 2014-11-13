using UnityEngine;
using System.Collections;

public class HelicopterMoving : MonoBehaviour
{
    float speed = 5.0f;
	float bombSpeed = 20f;

	public bool isAttacking = true;
	float height = 10f;
	float safeDistanceFromTarget = 60f;
	float retreatDirectionX = 0;
	float retreatDirectionZ = 0;

	GameObject projectile;

    GameObject target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
		projectile = Resources.Load("Prefabs/Bullets/bullet") as GameObject;
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
		transform.LookAt (new Vector3(retreatDirectionX, height, retreatDirectionZ));
		transform.position += transform.forward * speed * Time.deltaTime;
		
		if (calculateDistanceFromTarget() > safeDistanceFromTarget) {
			isAttacking = true;
		}
	}

	void dropBomb() {
		Debug.Log ("booombe !");
		GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, transform.position, Quaternion.identity);
		newProjectile.transform.LookAt(target.transform.position);
		newProjectile.renderer.material.color = Color.yellow;
		newProjectile.rigidbody.velocity = (newProjectile.transform.forward * bombSpeed);

	}

	float calculateDistanceFromTarget() {
		return (target.transform.position - transform.position).magnitude;
	}

	void calculateRetreatDirection() {
		retreatDirectionX = Random.value;
		retreatDirectionZ = Random.value;
	}

}
