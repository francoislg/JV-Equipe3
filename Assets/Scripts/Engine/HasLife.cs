using UnityEngine;
using System.Collections;

public abstract class HasLife : MonoBehaviour
{
    protected float life;
	public float maximumLife = 10;

	void Start(){
		life = maximumLife;
	}

    public virtual void ReceiveDamage(float damage)
    {
        life -= damage;
		OnReceiveDamage();
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

	public virtual void OnReceiveDamage() {}
    public abstract void OnDeath();

}
