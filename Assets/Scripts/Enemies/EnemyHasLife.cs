using UnityEngine;
using System.Collections;

public class EnemyHasLife : MonoBehaviour, HasLife
{
	public GameObject floatingTextClass;
	public GameObject floatingHealthClass;
	protected GameObject floatingHealthObject;
	protected FloatingHealth floatingHealthScript;

	protected float life;
	public float maximumLife = 10;

	public int pointsOnDeath = 5;

	public bool alive = true;

	void Start(){
		life = maximumLife;
		floatingHealthObject = Instantiate(floatingHealthClass, transform.position, Quaternion.identity) as GameObject;
		floatingHealthScript = floatingHealthObject.GetComponent<FloatingHealth>() as FloatingHealth;
		floatingHealthScript.target = this.gameObject;
		OnStart();
	}

	void Update(){
		Vector3 pos = transform.position;
		pos.y = 1;
		transform.position = pos;
		OnUpdate ();
	}

	public void ReceiveDamage(float damage)
	{
		if(alive){
			life -= damage;
			floatingHealthScript.setPctLife(life / maximumLife);
			createFloatingText(damage.ToString());
			if (life <= 0){
				die();
			}
		}
	}

	public bool isAlive(){
		return alive;
	}

	private void createFloatingText(string text){
		GameObject floatingText = Instantiate(floatingTextClass, transform.position, Quaternion.identity) as GameObject;
		floatingText.guiText.text = text;
	}

	private Vector2 getPositionOnScreen(){
		Vector3 targetPos = Camera.main.WorldToViewportPoint(transform.position);
		return new Vector2(targetPos.x, targetPos.y);
	}

	private void die(){
		GameObject.FindObjectOfType<PlayerStatus>().addPointsToScore(pointsOnDeath);
		Destroy (floatingHealthObject);
		alive = false;
		OnDeath ();
	}

	protected virtual void OnStart(){}
	protected virtual void OnUpdate(){}
	protected virtual void OnDeath(){}
}
