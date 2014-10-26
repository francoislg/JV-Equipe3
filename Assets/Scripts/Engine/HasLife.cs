using UnityEngine;
using System.Collections;

public abstract class HasLife : MonoBehaviour
{
    public float life = 10;

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

    public abstract void OnDeath();

}
