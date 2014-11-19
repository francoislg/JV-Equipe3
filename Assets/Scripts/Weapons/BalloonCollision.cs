using UnityEngine;
using System.Collections;

public class BalloonCollision : Munition
{
    public GameObject explosion;

    protected override void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
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
        Vector3 fwd = transform.forward;
        rigidbody.velocity = new Vector3(fwd.x * speed, (10 * fwd.y) + 7, fwd.z * speed);
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        // C'est vraiment comme ça qu'il faut faire...
        ContactPoint contact = other.contacts[0];
        Collider[] nearObjects = Physics.OverlapSphere(contact.point, 3);
        foreach (Collider collide in nearObjects)
        {
            if (joueur)
            {
                if (collide.gameObject.tag == "Enemy" || collide.gameObject.tag == "Spawner")
                {
                    HasLife enemyWithLife = collide.gameObject.GetComponent("HasLife") as HasLife;
                    enemyWithLife.ReceiveDamage(baseDamage);
                }
            }
            else
            {
                if (collide.gameObject.tag == "Player")
                {
					HasLife playerWithLife = collide.gameObject.GetComponent("HasLife") as HasLife;
                    playerWithLife.ReceiveDamage(baseDamage);
                }
            }
        }
        Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
    }
}