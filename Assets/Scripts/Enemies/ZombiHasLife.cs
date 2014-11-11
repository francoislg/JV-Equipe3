﻿using UnityEngine;
using System.Collections;

public class ZombiHasLife : HasLife
{
    ZombiAnimator animator;

	const int pointsForKill = 10;

    void Start()
    {
        animator = GetComponent<ZombiAnimator>();
    }

    public override void OnDeath()
    {
		GameObject.FindObjectOfType<PlayerStatus>().addPointsToScore(pointsForKill);

        animator.state = ZombiAnimator.State.Dying;
    }

}
