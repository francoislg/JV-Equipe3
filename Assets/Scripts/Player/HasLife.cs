using UnityEngine;
using System.Collections;

public class HasLife : MonoBehaviour {
    public GameObject deathExplosion;
    public float life = 10;

    public virtual void receiveDamage(float damage) {
        life -= damage;
        if (life <= 0) {
            onDeath();
        }
    }

    public virtual void onDeath() {
        Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject, 0.1f);
    }
}
