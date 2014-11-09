using UnityEngine;
using System.Collections;

public class ZombiHasLife : HasLife
{
    public GameObject deathExplosion;

    ZombiAnimator animator;

    void Start()
    {
        animator = GetComponent(typeof(ZombiAnimator)) as ZombiAnimator;
    }

    public override void OnDeath()
    {
        if (deathExplosion)
        {
            Instantiate(deathExplosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        }
        animator.state = ZombiAnimator.State.Dying;
    }

}
