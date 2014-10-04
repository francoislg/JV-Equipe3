using UnityEngine;
using System.Collections;

public class BaloonShooter : Weapon {
	private GameObject projectile;
	private float speed = 3f;
	public BaloonShooter(GameObject weaponHolder) : base(weaponHolder){
		this.cooldown = 0.5f;
		projectile = this.LoadBullet("bullet");
	}

	public override void shootAt(Vector3 target){
		GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, weaponHolder.transform.position, Quaternion.identity);
		newProjectile.renderer.material.color = Color.white;
		newProjectile.rigidbody.useGravity = true;
		newProjectile.transform.LookAt(target);
		Vector3 fwd = newProjectile.transform.forward;
		newProjectile.rigidbody.velocity = new Vector3(fwd.x * speed, (10 * fwd.y) + 15, fwd.z * speed);
	}

	public override void remove(){

	}
}
