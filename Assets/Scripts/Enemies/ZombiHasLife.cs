using UnityEngine;
using System.Collections;

public class ZombiHasLife : HasLife
{
    ZombiAnimator animator;

    void Start()
    {
        animator = GetComponent<ZombiAnimator>();
    }

    public override void OnDeath()
    {
        animator.state = ZombiAnimator.State.Dying;
    }

}
