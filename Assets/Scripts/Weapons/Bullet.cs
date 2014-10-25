using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int baseDamage = 10;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Spawner")
        {
            HasLife enemyWithLife = other.gameObject.GetComponent<HasLife>() as HasLife;
            enemyWithLife.ReceiveDamage(baseDamage);
            Destroy(gameObject);
        }
    }
}
