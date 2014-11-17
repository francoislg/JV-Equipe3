using UnityEngine;
using System.Collections;

// http://answers.unity3d.com/questions/122479/attack-damage-scrolling.html

public class FloatingText : MonoBehaviour {
	public Color color = new Color(0.8f,0.8f,0f,1.0f);
	public float scroll = 0.05f;  // scrolling velocity
	public float duration = 25f; // time to die
	public float alpha = 1;
	public Vector3 target;
	private float posy = 0;
	
	void Start(){
		guiText.material.color = color; // set text color
		alpha = 1;
	}
	
	void Update(){
		if (alpha > 0){
			posy += scroll * Time.deltaTime;

			Vector3 position = transform.position;
			Vector2 targetPosition = getTargetPositionOnScreen();
			position = targetPosition + new Vector2(0, posy);
			transform.position = position;

			alpha -= Time.deltaTime/duration; 
			Color c = guiText.material.color;
			c.a = alpha;
			guiText.material.color = c;
		} else {
			Destroy(gameObject); // text vanished - destroy itself
		}
	}

	private Vector2 getTargetPositionOnScreen(){
		Vector3 targetPos = Camera.main.WorldToViewportPoint(target);
		return new Vector2(targetPos.x, targetPos.y);
	}
}
