using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject copyUnit;
    protected float nextSpawn;
    protected float cooldown = 5f;
    protected float range = 25;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + cooldown;
            Vector3 randomPos = Random.insideUnitCircle * range;
            randomPos.z = randomPos.y;
            randomPos.y = 0;
            MonoBehaviour.Instantiate(copyUnit, transform.position + randomPos, Quaternion.identity);
        }
    }
}
