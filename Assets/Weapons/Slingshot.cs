using UnityEngine;
using System.Collections;

public class Slingshot : Weapon {
	private GameObject projectile;
	private float speed = 10.0f;
	public Slingshot(GameObject weaponHolder) : base(weaponHolder){
		projectile = (GameObject)Resources.Load("bullet", typeof(GameObject));
		projectile.renderer.material.color = Color.yellow;
	}

	public override void shootAt(Vector3 target){
		GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, weaponHolder.transform.position, Quaternion.identity);
		newProjectile.transform.LookAt(target);
		Debug.Log ("Target : " + target + " / Movement : " + newProjectile.transform.forward);
		newProjectile.rigidbody.velocity = (newProjectile.transform.forward * speed);
	}

	public override void remove(){

	}
}
