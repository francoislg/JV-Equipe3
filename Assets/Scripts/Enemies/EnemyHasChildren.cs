using UnityEngine;
using System.Collections;

public class EnemyHasChildren : EnemyHasLife
{
	public GameObject deathExplosion;
	public string childrenType;

    protected override void OnDeath()
    {
		base.OnDeath();
		GameObject[] go = GameObject.FindGameObjectsWithTag(childrenType);
		for(int i=0; i<go.Length; i++)
        {
			Instantiate(deathExplosion, go[i].transform.position, Quaternion.Euler(90, 0, 0));
			Destroy(go[i]);
        }
		Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }

}

