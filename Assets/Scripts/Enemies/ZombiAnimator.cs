using UnityEngine;
using System.Collections;

public class ZombiAnimator : MonoBehaviour
{
    public enum State
    {
        Walking,
        Attacking,
        Dying
    };

    public State state;

    void Start()
    {
        state = State.Walking;
    }

    void Update()
    {
        if (state == State.Walking)
        {
            transform.animation.Play("walk01");
        }
        else if (state == State.Attacking)
        {
            transform.animation.Play("attack01");
        }
        else if (state == State.Dying)
        {
            transform.animation.Play("death");
            Destroy(gameObject, 1.6f);
        }
    }
}
