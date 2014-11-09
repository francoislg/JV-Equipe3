using UnityEngine;
using System.Collections;

public class EnemyMoving : MonoBehaviour
{
    public float speed = 1.0f;

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
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
