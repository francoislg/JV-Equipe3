using UnityEngine;
using System.Collections;

public class HelicopterMoving : MonoBehaviour
{
    private const float Speed = 8.0f;
    private const float Height = 10f;
    private const float DistanceToHit = 12f;
    private const float SafeDistanceFromTarget = 50f;
    private const float VisibilityRange = 25;

    enum State
    {
        Waiting, Attacking, Retreating
    }

    State _state;
    Vector3 _retreatDirection;
    GameObject _target;
    Weapon _arme;
    Transform _bulletPool;

    void Start()
    {
        _state = State.Waiting;
        _retreatDirection = new Vector3(0, 0, 0);
        _target = GameObject.FindGameObjectWithTag("Player");

        InitBulletPool();
        InitArme();
    }

    void InitBulletPool()
    {
        var obj = new GameObject("MunitionPool");
        obj.transform.position = new Vector3(0, -10, 0);
        _bulletPool = obj.transform;
    }

    void InitArme()
    {
        _arme = gameObject.AddComponent("BalloonShooter") as Weapon;
        if (_arme != null)
        {
            _arme.InitWeapon(gameObject, _bulletPool, 1, 1, 10, 20, 10, 0, Color.yellow, false);
        }
    }

    void Update()
    {
        switch (_state)
        {
            case State.Attacking:
                Attack();
                break;
            case State.Retreating:
                Retreat();
                break;
            case State.Waiting:
                Wait();
                break;
        }
    }

    void Attack()
    {
        transform.LookAt(_target.transform.position + new Vector3(0, Height, 0));
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (CalculateDistanceFromTarget() < DistanceToHit)
        {
            DropBomb();
            CalculateRetreatDirection();
            _state = State.Retreating;
        }
    }

    void Retreat()
    {
        transform.LookAt(_retreatDirection);
        transform.position += transform.forward * Speed * Time.deltaTime;

        if (CalculateDistanceFromTarget() > SafeDistanceFromTarget)
        {
            _state = State.Attacking;
        }
    }

    void Wait()
    {
        if (CalculateDistanceFromTarget() < VisibilityRange)
        {
            _state = State.Attacking;
        }
    }

    void DropBomb()
    {
        _arme.ShootAt(_target.transform.position);
    }

    float CalculateDistanceFromTarget()
    {
        return (_target.transform.position - transform.position).magnitude;
    }

    void CalculateRetreatDirection()
    {
        _retreatDirection = transform.position + new Vector3(Random.Range(-1000f, 1000f), 0, Random.Range(-1000f, 1000f));
    }

}
