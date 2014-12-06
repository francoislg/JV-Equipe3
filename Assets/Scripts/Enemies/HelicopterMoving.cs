using UnityEngine;
using System.Collections;

public class HelicopterMoving : MonoBehaviour
{
    float speed = 8.0f;

	public bool isAttacking = true;
	float height = 10f;
	float distanceToHit = 12f;

	float safeDistanceFromTarget = 50f;
	Vector3 retreatDirection;

	//GameObject projectile;
    //float bombSpeed = 20f;

    GameObject target;

    /* CHANGEMENT */
    Weapon arme;
    Transform bulletPool;
    /**/

    void Start() {
		retreatDirection = new Vector3 (0, 0, 0);
        target = GameObject.FindGameObjectWithTag("Player");
		//projectile = Resources.Load("Prefabs/Bullets/ennemyBullet") as GameObject;

        /*CHANGEMENT*/
        GameObject obj = new GameObject("MunitionPool");
        obj.transform.position = new Vector3(0, -10, 0);
        bulletPool = obj.transform;
        arme = gameObject.AddComponent("BalloonShooter") as Weapon;
        arme.InitWeapon(gameObject, bulletPool, 1, 1, 10, 20, 10, 0, Color.yellow, false);
        /**/

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
		
		if (calculateDistanceFromTarget() < distanceToHit) {
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

        arme.ShootAt(target.transform.position);
        /*
		GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, transform.position, Quaternion.identity);
		newProjectile.transform.LookAt(target.transform.position);
		newProjectile.renderer.material.color = Color.yellow;
		newProjectile.rigidbody.velocity = (newProjectile.transform.forward * bombSpeed);
        */
	}

	float calculateDistanceFromTarget() {
		return (target.transform.position - transform.position).magnitude;
	}

	void calculateRetreatDirection() {
		retreatDirection = transform.position + new Vector3 (Random.Range (-1000f, 1000f), 0, Random.Range (-1000f, 1000f));
	}

}
