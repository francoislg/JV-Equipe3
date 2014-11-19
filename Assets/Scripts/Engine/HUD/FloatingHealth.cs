using UnityEngine;
using System.Collections;

public class FloatingHealth : MonoBehaviour {
	public GameObject target;
	private Vector2 offset = new Vector2(0, 0.03f);
	private float pctLife = 1;
	private Transform healthBar;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(-10,-10);
		healthBar = transform.Find("HealthBar") as Transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(pctLife != 1){
			transform.position = getTargetPositionOnScreen() + offset;
		}
	}

	public void setPctLife(float pct){
		pctLife = Mathf.Clamp(pct, 0.0f, 1.0f);
		Vector3 scale = healthBar.transform.localScale;
		scale.x = pct;
		healthBar.transform.localScale = scale;

		Color color = new Color((1 - pct), pct, 0);
		healthBar.guiTexture.color = color;
	}

	private Vector2 getTargetPositionOnScreen(){
		Vector3 targetPos = Camera.main.WorldToViewportPoint(target.transform.position);
		return new Vector2(targetPos.x, targetPos.y);
	}
}
