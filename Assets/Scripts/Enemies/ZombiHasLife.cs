using UnityEngine;
using System.Collections;

public class ZombiHasLife : EnemyHasLife
{
    ZombiAnimator animator;

	public const int pointsForKill = 10;

	protected override void OnStart(){
		base.OnStart();
		animator = GetComponent<ZombiAnimator>();
	}

    protected override void OnDeath()
    {
		base.OnDeath();
        animator.state = ZombiAnimator.State.Dying;
    }

}
