using UnityEngine;
using System.Collections;

public class EnemyHasChildren : EnemyHasLife
{
    public GameObject deathExplosion;
    public GameObject copyUnit;
    public int nbEnemies = 3;
    public int range = 5;

    readonly ArrayList _children = new ArrayList();

    protected override void OnStart()
    {
        for (int i = 0; i < nbEnemies; i++)
        {
            Vector3 randomPos = Random.insideUnitCircle * range;
            randomPos.z = randomPos.y;
            randomPos.y = 0;
            _children.Add(Instantiate(copyUnit, transform.position + randomPos, Quaternion.identity));
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        foreach (GameObject child in _children)
        {
            Instantiate(deathExplosion, child.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(child);
        }
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }

}

