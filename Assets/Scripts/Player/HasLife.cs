using UnityEngine;
using System.Collections;

public class HasLife : MonoBehaviour
{
    public GameObject deathExplosion;
    public float life = 10;

    public bool zombi;
    ZombiAnimator animator;

    void Start()
    {
        if (zombi)
        {
            animator = (ZombiAnimator)GetComponent(typeof(ZombiAnimator));
        }
    }

    public virtual void ReceiveDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            OnDeath();
        }
    }

    public virtual void PushFromSource(Vector3 source, float force)
    {
        Vector3 direction = transform.position - source;
        direction.Normalize();
        rigidbody.AddForce(direction * force);
    }

    public virtual void OnDeath()
    {
        if (deathExplosion)
        {
            Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        }

        if (zombi)
        {
            animator.state = ZombiAnimator.State.Dying;
        }

        else
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
