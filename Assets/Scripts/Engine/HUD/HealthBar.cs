using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private Texture2D healthBarContainer;
	private Texture2D healthBar;
	private GameObject target;

	// Use this for initialization
	void Start () {
		healthBarContainer = Resources.Load("Sprites/healthBarFull") as Texture2D;
		healthBar = Resources.Load("Sprites/healthBarEmpty") as Texture2D;
	}

	public void update(){
		if(target){
			HasLife hasLife = target.GetComponent("HasLife") as HasLife;
		}
	}

	public void setTarget(GameObject target){
		this.target = target;
	}
}
