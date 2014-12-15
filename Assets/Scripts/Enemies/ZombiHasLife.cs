using UnityEngine;
using System.Collections;

public class ZombiHasLife : EnemyHasLife
{
	public const int pointsForKill = 10;

    ZombiAnimator _animator;

	protected override void OnStart(){
		base.OnStart();
		_animator = GetComponent<ZombiAnimator>();
	}

    protected override void OnDeath()
    {
		base.OnDeath();
        _animator.state = ZombiAnimator.State.Dying;
    }

}
