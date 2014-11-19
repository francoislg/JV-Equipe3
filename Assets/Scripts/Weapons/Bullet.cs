using UnityEngine;
using System.Collections;

public class Bullet : Munition
{
    protected override void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
        if (!Expirer && Actif)
        {        
            rigidbody.velocity = transform.forward * speed;
        }

        if (!Expirer && Time.time - creationTimeStamp > duration)
        {
            Recyle();
        }
    }

    public override void Fire(Vector3 target)
    {
        base.Fire(target);
        renderer.material.color = color;
        audio.Play();
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (joueur)
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Spawner")
            {
                HasLife enemyWithLife = other.gameObject.GetComponent<HasLife>() as HasLife;
                enemyWithLife.ReceiveDamage(baseDamage);
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                HasLife playerWithLife = other.gameObject.GetComponent<HasLife>() as HasLife;
                playerWithLife.ReceiveDamage(baseDamage);
            }
        }
    }
}

