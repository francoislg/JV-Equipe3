using UnityEngine;
using System.Collections;

public class EnemyHasLife : MonoBehaviour, HasLife
{
	private Texture2D healthBarContainer;
	private Texture2D healthBar;
	protected float life;
	public float maximumLife = 10;

	public int pointsOnDeath = 5;

	void Start(){
		life = maximumLife;
		healthBarContainer = Resources.Load("Sprites/healthBarContainer") as Texture2D;
		healthBar = Resources.Load("Sprites/healthBar") as Texture2D;
		OnStart();
	}

	void Update(){
		if(life != maximumLife){
			Vector3 targetPos = Camera.main.WorldToScreenPoint(transform.position);
			targetPos.y = Screen.height - targetPos.y;
			Rect position = new Rect(targetPos.x, targetPos.z, healthBarContainer.width, healthBarContainer.height);
			GUI.DrawTexture(position, healthBar);
			GUI.DrawTexture(position, healthBarContainer);
		}
	}

	public void ReceiveDamage(float damage)
	{
		life -= damage;
		if (life <= 0)
		{
			die();
		}
	}

	private void die(){
		GameObject.FindObjectOfType<PlayerStatus>().addPointsToScore(pointsOnDeath);
		OnDeath ();
	}

	protected virtual void OnStart(){}
	protected virtual void OnDeath(){}
}
