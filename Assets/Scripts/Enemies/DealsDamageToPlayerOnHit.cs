using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour
{
    public int damageCount = 10;

    protected EnemyHasLife Enemy;
    protected bool IsActive;
    protected PlayerHasLife Player;

    protected virtual void Start()
    {
        IsActive = true;
        Enemy = GetComponent<EnemyHasLife>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHasLife>();
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (Enemy != null && !Enemy.alive)
        {
            IsActive = false;
        }
        if (IsActive && other.gameObject.tag == "Player")
        {
            OnCollisionWithPlayer();
        }
    }

    public void DealDamage()
    {
        Player.ReceiveDamage(damageCount);
        Player.PushFromSource(transform.position, damageCount);
    }

    protected virtual void OnCollisionWithPlayer() { }
}
