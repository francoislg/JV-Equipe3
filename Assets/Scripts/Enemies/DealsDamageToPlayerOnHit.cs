using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour
{
    public int damageCount = 10;
	private EnemyHasLife enemyObject;
	private bool isActive = true;

    void Start()
    {
        enemyObject = GetComponent<EnemyHasLife>() as EnemyHasLife;
    }

    void OnCollisionEnter(Collision other)
    {
		if(enemyObject != null){
			if(!enemyObject.isAlive()){
				isActive = false;
			}
		}
		if (isActive && other.gameObject.tag == "Player")
        {
			PlayerHasLife playerLife = other.gameObject.GetComponent<PlayerHasLife>() as PlayerHasLife;
			playerLife.ReceiveDamage(damageCount);
			playerLife.PushFromSource(transform.position, damageCount);
        }
    }
}
