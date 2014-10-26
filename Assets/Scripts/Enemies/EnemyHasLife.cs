using UnityEngine;
using System.Collections;

public class EnemyHasLife : HasLife
{
    public GameObject deathExplosion;

    public override void OnDeath()
    {
        if (deathExplosion)
        {
            Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        }
        Destroy(gameObject);
    }

}
