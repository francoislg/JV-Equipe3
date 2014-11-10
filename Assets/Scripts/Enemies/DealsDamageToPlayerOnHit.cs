using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour
{
    public int damageCount = 10;
    public double attackAnnimationSpeed;

    ZombiAnimator animator;
    float attackStartTime;

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
            attackStartTime = Time.time;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" &&
            animator.state != ZombiAnimator.State.Dying &&
            Time.time - attackStartTime > attackAnnimationSpeed)
        {
            PlayerHasLife playerLife = other.gameObject.GetComponent<PlayerHasLife>() as PlayerHasLife;
            playerLife.ReceiveDamage(damageCount);
            playerLife.PushFromSource(transform.position, damageCount * 100);
            attackStartTime = Time.time;
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
