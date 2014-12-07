using UnityEngine;


public class EndGameMenu : MonoBehaviour
{
	static public int finalScore = 0;
	
	const int buttonWidth = 200;
	const int buttonHeight = 60;
	const int scoreZoneWidth = 250;
	const int scoreZoneHeight = 25;
	const int margin = 10;

	Rect statusZone;
	Rect menuButton;
	ScreenFader fader;
	
	void Start()
	{		
		fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

		statusZone = new Rect(Screen.width/2 - scoreZoneWidth/2, (Screen.height / 2) - (buttonHeight / 2), scoreZoneWidth, scoreZoneHeight);

		menuButton = new Rect(
			(Screen.width / 2) - (buttonWidth / 2),
			(Screen.height / 4) - (buttonHeight / 4),
			buttonWidth,
			buttonHeight
			);

	}
	
	void OnGUI()
	{
		GUI.TextArea(statusZone, "Final score : " + finalScore);

		if (!fader.SceneEnding && !fader.SceneStarting)
		{
			if (GUI.Button(menuButton, "Retour au menu principal"))
			{
				fader.GotoScene("MenuScene");
			}
		}
	}	
}
