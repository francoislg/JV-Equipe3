using UnityEngine;
using System.Collections;

public class HasLife : MonoBehaviour {
    public GameObject deathExplosion;
    protected int life = 100;

    public virtual void receiveDamage(int damage) {
        life -= damage;
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject, 0.1f);
    }

    public bool isDead() {
        return life <= 0;
    }
}
