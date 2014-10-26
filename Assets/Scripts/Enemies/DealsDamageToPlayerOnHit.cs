using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour
{
    public int damageCount = 10;
    private ZombiAnimator animator;

    private float DebutAttaque;
    public double TempsAnimationAttaque;

    void Start()
    {
        animator = (ZombiAnimator)GetComponent(typeof(ZombiAnimator));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" &&
            animator.state != ZombiAnimator.State.Dying)
        {
            animator.state = ZombiAnimator.State.Attacking;
            DebutAttaque = Time.time;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" &&
            animator.state != ZombiAnimator.State.Dying &&
            Time.time - DebutAttaque > TempsAnimationAttaque)
        {
            PlayerHasLife playerLife = other.gameObject.GetComponent<PlayerHasLife>() as PlayerHasLife;
            playerLife.ReceiveDamage(damageCount);
            playerLife.PushFromSource(transform.position, damageCount * 100);
            DebutAttaque = Time.time;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (animator.state != ZombiAnimator.State.Dying)
        {
            animator.state = ZombiAnimator.State.Walking;
        }
    }



}
