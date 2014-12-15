using UnityEngine;
using System.Collections;

public class ZombiAI : MonoBehaviour
{
    public float speed = 5.0f;

    GameObject _target;
    ZombiAnimator _animator;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _animator = (ZombiAnimator)GetComponent(typeof(ZombiAnimator));
    }

    void Update()
    {
        if (_animator.state != ZombiAnimator.State.Dying)
        {
            transform.LookAt(_target.transform.position);
            rigidbody.velocity = transform.forward * speed;
        }
    }
}
