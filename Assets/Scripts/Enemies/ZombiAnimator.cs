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
	public float attackStartTime = 10;
	public float attackAnimationSpeed = 0;

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

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player" &&
		    state != ZombiAnimator.State.Dying)
		{
			state = ZombiAnimator.State.Attacking;
			attackStartTime = Time.time;
		}
	}
	
	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Player" &&
		    state != ZombiAnimator.State.Dying &&
		    Time.time - attackStartTime > 0)
		{
			attackStartTime = Time.time;
		}
	}
	
	void OnCollisionExit(Collision other)
	{
		if (state != ZombiAnimator.State.Dying)
		{
			state = ZombiAnimator.State.Walking;
		}
	}
}
