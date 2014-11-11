using UnityEngine;
using System.Collections;

public class HudStatus : MonoBehaviour
{

	int playerLevel = 1;
	int attackBonus = 1;
	int speedBonus = 1;
	const int height = 25;
	const int width = 350;
	const int margin = 10;

	Rect statusZone;

    void Start()
    {		
		statusZone = new Rect(Screen.width - margin - width, margin, width, height);
    }

    void Update()
    {

    }

    void OnGUI()
    {
		GUI.TextArea(statusZone, "Level : " + playerLevel + "  Attack : " + attackBonus + "  Speed : " + speedBonus);
    }
	

	public void setPlayerLevel(int level) {
		playerLevel = level;
	}

	public void setAttackBonus(int attack) {
		attackBonus = attack;
	}

	public void setSpeedBonus(int speed) {
		speedBonus = speed;
	}

}
