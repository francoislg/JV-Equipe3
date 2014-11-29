﻿using UnityEngine;
using System.Collections;

public class ZombiAI : MonoBehaviour
{
    public float speed = 5.0f;

    GameObject target;
    ZombiAnimator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = (ZombiAnimator)GetComponent(typeof(ZombiAnimator));
    }

    void Update()
    {
        if (animator.state != ZombiAnimator.State.Dying)
        {
            transform.LookAt(target.transform.position);
            rigidbody.velocity = transform.forward * speed;
        }
    }
}
