using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.gameObject.collider2D, this.collider2D);
        }
    }

}
