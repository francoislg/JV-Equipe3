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
		GameObject go = GameObject.Find("GameController");
		HudScore points = (HudScore) go.GetComponent(typeof(HudScore));
		points.addToScore (10);

        animator.state = ZombiAnimator.State.Dying;
    }

}
