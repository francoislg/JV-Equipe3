using UnityEngine;
using System.Collections;

public class HasLife : MonoBehaviour {
    public GameObject deathExplosion;
    protected float life = 10;

    public virtual void receiveDamage(float damage) {
        life -= damage;
        if (life <= 0) {
            Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
            Destroy(gameObject, 0.1f);
        }
    }
}
