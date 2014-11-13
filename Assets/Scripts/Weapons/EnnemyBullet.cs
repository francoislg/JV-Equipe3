using UnityEngine;
using System.Collections;

public class EnnemyBullet : MonoBehaviour
{
    public int baseDamage = 10;


    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Player")
        {
            HasLife playerWithLife = other.gameObject.GetComponent<HasLife>() as HasLife;
			playerWithLife.ReceiveDamage(baseDamage);
            Destroy(gameObject);
        }
    }
}
