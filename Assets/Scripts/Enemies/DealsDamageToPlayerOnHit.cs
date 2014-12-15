using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour
{
    public int damageCount = 10;
	protected EnemyHasLife enemyObject;
	protected bool isActive = true;
    public PlayerHasLife playerLife;

    void Start()
    {
        enemyObject = GetComponent<EnemyHasLife>() as EnemyHasLife;
		playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHasLife>() as PlayerHasLife;
    }

	protected virtual void OnCollisionEnter(Collision other)
    {
		if(enemyObject != null){
			if(!enemyObject.isAlive()){
				isActive = false;
			}
		}
		if(isActive && other.gameObject.tag == "Player"){
			OnCollisionWithPlayer();
		}
    }

	protected virtual void OnCollisionWithPlayer() {}

    public void DealDamage ()
    {
		playerLife.ReceiveDamage(damageCount);
		playerLife.PushFromSource(transform.position, damageCount);
    }
}
