using UnityEngine;
using System.Collections;

public class ZombiAnimator : DealsDamageToPlayerOnHit
{
    public enum State
    {
        Walking,
        Attacking,
        Dying
    };

    public State state;
    public float attackStartTime;
    public float attackAnimationSpeed;

    protected override void Start()
    {
        base.Start();

        var annimationComponent = GetComponent<Animation>();
        annimationComponent["attack01"].speed = 3.0f;

        attackStartTime = 10;
        attackAnimationSpeed = 0.4f;
        state = State.Walking;
    }

    void Update()
    {
        if (state == State.Walking)
        {
            transform.animation.Play("walk01");
        }
        else if (state == State.Attacking)
        {
            transform.animation.Play("attack01");
        }
        else if (state == State.Dying)
        {
            transform.animation.Play("death");
            var boxCollider = GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            Destroy(gameObject, 1.6f);
        }
    }

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);

        if (other.gameObject.tag == "Player" &&
            state != State.Dying)
        {
            state = State.Attacking;
            attackStartTime = Time.time;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" &&
            state != State.Dying &&
            Time.time - attackStartTime > attackAnimationSpeed)
        {
            base.DealDamage();
            attackStartTime = Time.time;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (state != State.Dying)
        {
            state = State.Walking;
        }
    }
}
