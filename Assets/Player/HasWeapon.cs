using UnityEngine;
using System.Collections;

public class HasWeapon : MonoBehaviour {
	private Weapon weapon;
	private float cooldownUntil;
	private bool onCooldown;
	// Use this for initialization
	void Start () {
		weapon = new Slingshot(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		checkCooldown();
		if(!onCooldown) {
			if(Input.GetMouseButton(0)){
				Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit mouseRayHit;
				if(Physics.Raycast(mouseRay, out mouseRayHit)){
					weapon.shootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
					setCooldown(weapon.getCooldown());
				}
			}
		}
	}

	private void checkCooldown(){
		if(onCooldown){
			if(Time.time > cooldownUntil){
				onCooldown = false;
			}
		}
	}

	private void setCooldown(float cooldown){
		onCooldown = true;
		cooldownUntil = Time.time + cooldown;
	}
}
