using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
	int score = 0;
	int level = 1;
	private float attackBonus;
	public float attack {
		get{
			return attackBonus;
		}
		protected set{
			attackBonus = value;
		}
	}
	private float speedBonus;
	public float speed {
		get{
			return speedBonus + getInventorySpeed();
		}
		protected set{
			speedBonus = value;
		}
	}

	GameObject go;
	HudStatus hudStatus;
	HudScore hudScore;
	PlayerHasInventory inventory;

	void Start() {
		go = GameObject.Find("GameController");
		hudStatus = (HudStatus) go.GetComponent(typeof(HudStatus));
		hudScore = (HudScore) go.GetComponent(typeof(HudScore));
		inventory = GetComponent<PlayerHasInventory>() as PlayerHasInventory;
	}

	void Update()
	{
		if (score > 100 * level) {
			levelUp();
			hudStatus.playerLevel = level;
			hudStatus.attackBonus = attackBonus;
			hudStatus.speedBonus = speedBonus;
		}
		
	}

	private float getInventorySpeed(){
		if(inventory){
			return inventory.speed;
		}
		return 0;
	}

	public void levelUp() {
		level++;
		attackBonus += 0.5f;
		speedBonus += 0.1f;
	}

	public void addPointsToScore(int points) {
        score += points;
        hudScore.playerScore = score;
	}
}
