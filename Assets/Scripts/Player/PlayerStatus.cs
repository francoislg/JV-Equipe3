using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{

	int score = 0;
	int level = 1;
	int attackBonus = 0;
	int speedBonus = 0;

	GameObject go;
	HudStatus hudStatus;
	HudScore hudScore;

	void Start() {
		go = GameObject.Find("GameController");
		hudStatus = (HudStatus) go.GetComponent(typeof(HudStatus));
		hudScore = (HudScore) go.GetComponent(typeof(HudScore));
	}

	void Update()
	{

		if (score > 100 * level) {
			levelUp();
			hudStatus.setPlayerLevel(level);
			hudStatus.setAttackBonus(attackBonus);
			hudStatus.setSpeedBonus(speedBonus);
		}
		
	}

	public void levelUp() {
		level++;
		attackBonus += 2;
		speedBonus += 1;
	}

	public void addPointsToScore(int points) {
		score += points;
		hudScore.setPlayerScore (score);
	}
}
