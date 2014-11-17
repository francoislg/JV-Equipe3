using UnityEngine;
using System.Collections;

public class EnemyHasLife : MonoBehaviour, HasLife
{
	public GameObject floatingTextObject;

	private Texture2D healthBarContainer;
	private Texture2D healthBar;
	protected float life;
	public float maximumLife = 10;

	public int pointsOnDeath = 5;

	void Start(){
		life = maximumLife;
		healthBarContainer = Resources.Load("Sprites/healthBarContainer") as Texture2D;
		healthBar = Resources.Load("Sprites/healthBar") as Texture2D;
		//GUI.DrawTexture(new Rect(0,0, healthBar.width, healthBar.height), healthBarContainer);
		OnStart();
	}

	void Update(){
		if(life != maximumLife){
			/*Vector2 posOnScreen = getPositionOnScreen();
			Rect position = new Rect(posOnScreen.x, posOnScreen.y, healthBarContainer.width, healthBarContainer.height);
			GUI.DrawTexture(position, healthBar);
			GUI.DrawTexture(position, healthBarContainer);*/
		}
	}

	public void ReceiveDamage(float damage)
	{
		life -= damage;
		createFloatingText(damage.ToString());
		if (life <= 0)
		{
			die();
		}
	}

	private void createFloatingText(string text){
		GameObject floatingText = Instantiate(floatingTextObject, new Vector2(0,0), Quaternion.identity) as GameObject;
		FloatingText floatComponent = floatingText.GetComponent("FloatingText") as FloatingText;
		floatComponent.target = transform.position;
		floatingText.guiText.text = text;
	}

	private Vector2 getPositionOnScreen(){
		Vector3 targetPos = Camera.main.WorldToViewportPoint(transform.position);
		return new Vector2(targetPos.x, targetPos.y);
	}

	private void die(){
		GameObject.FindObjectOfType<PlayerStatus>().addPointsToScore(pointsOnDeath);
		OnDeath ();
	}

	protected virtual void OnStart(){}
	protected virtual void OnDeath(){}
}
