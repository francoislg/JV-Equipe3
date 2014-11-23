using UnityEngine;
using System.Collections;

public class SpawnerHasLife : EnemyHasLife {
	public GameObject deathExplosion;

	protected override void OnDeath()
	{
		base.OnDeath();
		if(deathExplosion){
			Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
		}
		Destroy(gameObject);
	}
}
