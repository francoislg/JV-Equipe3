using UnityEngine;
using System.Collections;

public class SpawnerHasLife : EnemyHasLife {
	public GameObject deathExplosion;
	public const int pointsOnDeath = 10;

	protected override void OnDeath()
	{
		base.OnDeath();
		Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
		Destroy(gameObject);
	}
}
