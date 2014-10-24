using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour
{
    public int damageCount = 10;
    ZombiAnimator animator;

    float DebutAttaque;
    public double TempsAnimationAttaque;

    void Start()
    {
        animator = (ZombiAnimator)GetComponent(typeof(ZombiAnimator));
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (animator.state != ZombiAnimator.State.Dying)
            {
                Debug.Log("Entrer dans la collision");
                animator.state = ZombiAnimator.State.Attacking;
                DebutAttaque = Time.time;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (animator.state != ZombiAnimator.State.Dying)
            {
                if (Time.time - DebutAttaque > TempsAnimationAttaque)
                {
                    PlayerHasLife playerLife = other.GetComponent<PlayerHasLife>() as PlayerHasLife;
                    playerLife.ReceiveDamage(damageCount);
                    playerLife.PushFromSource(transform.position, damageCount * 100);
                    DebutAttaque = Time.time;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (animator.state != ZombiAnimator.State.Dying)
        {
            Debug.Log("Sortie de collision");
            animator.state = ZombiAnimator.State.Walking;
        }
    }



}
