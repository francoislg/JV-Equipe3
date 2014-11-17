using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int baseDamage = 10;

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            Collider pc = p.GetComponent<Collider>();
            if (pc)
            {
                Physics.IgnoreCollision(pc, collider);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Spawner")
        {
			HasLife enemyWithLife = other.gameObject.GetComponent("HasLife") as HasLife;
            enemyWithLife.ReceiveDamage(baseDamage);
            Destroy(gameObject);
        }
    }
}
