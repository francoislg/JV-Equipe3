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

	public bool isDead = false;

	void Start(){
		life = maximumLife;
		floatingHealthObject = Instantiate(floatingHealthClass, transform.position, Quaternion.identity) as GameObject;
		floatingHealthScript = floatingHealthObject.GetComponent<FloatingHealth>() as FloatingHealth;
		floatingHealthScript.target = this.gameObject;
		OnStart();
	}

	void Update(){

	}

	public void ReceiveDamage(float damage)
	{
		if(!isDead){
			life -= damage;
			floatingHealthScript.setPctLife(life / maximumLife);
			createFloatingText(damage.ToString());
			if (life <= 0){
				die();
			}
		}
	}

	private void createFloatingText(string text){
		GameObject floatingText = Instantiate(floatingTextClass, transform.position, Quaternion.identity) as GameObject;
		FloatingText floatComponent = floatingText.GetComponent("FloatingText") as FloatingText;
		floatingText.guiText.text = text;
	}

	private Vector2 getPositionOnScreen(){
		Vector3 targetPos = Camera.main.WorldToViewportPoint(transform.position);
		return new Vector2(targetPos.x, targetPos.y);
	}

	private void die(){
		GameObject.FindObjectOfType<PlayerStatus>().addPointsToScore(pointsOnDeath);
		Destroy (floatingHealthObject);
		isDead = true;
		OnDeath ();
	}

	protected virtual void OnStart(){}
	protected virtual void OnDeath(){}
}
