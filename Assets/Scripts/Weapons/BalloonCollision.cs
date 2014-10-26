using UnityEngine;
using System.Collections;

public class BalloonCollision : MonoBehaviour
{
    public GameObject explosion;
    public int baseDamage = 10;

    void Start()
    {
        renderer.material.color = Color.blue;
    }

    void OnCollisionEnter(Collision other)
    {
        // C'est vraiment comme ça qu'il faut faire...
        ContactPoint contact = other.contacts[0];

        Collider[] nearObjects = Physics.OverlapSphere(contact.point, 3);
        bool hasCollideEnemy = false;
        foreach (Collider collide in nearObjects)
        {
            if (collide.tag == "Enemy" || collide.tag == "Spawner")
            {
                HasLife enemyWithLife = collide.GetComponent<HasLife>() as HasLife;
                enemyWithLife.ReceiveDamage(baseDamage);
                hasCollideEnemy = true;
            }
        }
        if (hasCollideEnemy)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
    }
}