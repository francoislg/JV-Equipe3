using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public int baseDamage = 10;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HasLife enemyWithLife = other.gameObject.GetComponent<HasLife>() as HasLife;
            enemyWithLife.receiveDamage(baseDamage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.gameObject.collider2D, this.collider2D);
        }
    }

}
