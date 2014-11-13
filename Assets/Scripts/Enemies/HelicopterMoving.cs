using UnityEngine;
using System.Collections;

public class HelicopterMoving : MonoBehaviour
{
    float speed = 5.0f;
	public bool isAttacking = true;
	float height = 10f;
	float safeDistanceFromTarget = 60f;
	float retreatDirectionX = 0;
	float retreatDirectionZ = 0;

    GameObject target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
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
	}

	float calculateDistanceFromTarget() {
		return (target.transform.position - transform.position).magnitude;
	}

	void calculateRetreatDirection() {
		retreatDirectionX = Random.value;
		retreatDirectionZ = Random.value;
	}

}
