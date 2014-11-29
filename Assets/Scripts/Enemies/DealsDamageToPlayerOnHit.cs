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
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
		if(enemyObject != null){
			if(!enemyObject.isAlive()){
				isActive = false;
			}
		}
		if (isActive && other.gameObject.tag == "Player")
        {
            playerLife = other.gameObject.GetComponent<PlayerHasLife>() as PlayerHasLife;
            //DealDamage();
        }
    }

    public void DealDamage ()
    {
		playerLife.ReceiveDamage(damageCount);
		playerLife.PushFromSource(transform.position, damageCount);
    }
}
