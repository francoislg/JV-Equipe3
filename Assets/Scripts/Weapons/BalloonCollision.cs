using UnityEngine;
using System.Collections;

public class BalloonCollision : MonoBehaviour {
	public GameObject explosion;
    public int damage = 10;

    void OnCollisionEnter(Collision other) {
        // C'est vraiment comme ça qu'il faut faire...
        ContactPoint contact = other.contacts[0];

        Collider[] nearObjects = Physics.OverlapSphere(contact.point, 5);
        foreach (Collider collide in nearObjects) {
            if (collide.tag == "Enemy") {
                HasLife enemyWithLife = collide.GetComponent<HasLife>() as HasLife;
                enemyWithLife.receiveDamage(damage);
            }
        }
        Instantiate(explosion, contact.point, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }
}
