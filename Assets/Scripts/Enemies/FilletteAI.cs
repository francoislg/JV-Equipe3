using UnityEngine;
using System.Collections;

public class FilletteAI : EnemyHasLife
{
    protected Animator Animator;
    protected GameObject Target;
    protected int Range;
    protected float Acceleration;

    protected override void OnStart()
    {
        Range = 15;
        Acceleration = 0.3f;
        Animator = GetComponentInChildren<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player");
        rigidbody.velocity = Vector3.zero;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.LookAt(Target.transform.position);

        if (!Animator) return;

        if (Animator.GetBool("IsInRange"))
        {
            rigidbody.velocity += transform.forward * Acceleration;
        }
        else if (Vector3.Distance(transform.position, Target.transform.position) < Range)
        {
            Animator.SetBool("IsInRange", true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag != "Player")
        {
            Physics.IgnoreCollision(other.collider, collider);
        }
        rigidbody.velocity = Vector3.zero;
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        Destroy(gameObject);
    }
}
