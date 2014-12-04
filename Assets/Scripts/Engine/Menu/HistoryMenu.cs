using UnityEngine;


public class HistoryMenu : MonoBehaviour
{
	const int buttonWidth = 200;
	const int buttonHeight = 60;
	const int margin = 10;
	
	Rect playButton;
	Rect tutoButton;
	ScreenFader fader;
	
	void Start()
	{
		
		fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
		
		playButton = new Rect(
			(Screen.width / 2) - (buttonWidth / 2),
			(Screen.height / 4) - (buttonHeight / 4),
			buttonWidth,
			buttonHeight
			);
		
		tutoButton = new Rect(
			playButton.xMin,
			playButton.yMax + margin,
			buttonWidth,
			buttonHeight
			);
	}
	
	void OnGUI()
	{
		if (!fader.SceneEnding && !fader.SceneStarting)
		{
			if (GUI.Button(playButton, "Commencer l'aventure !"))
			{
				fader.GotoScene("GameScene");
			}
			else if (GUI.Button(tutoButton, "Commencer au niveau tutoriel"))
			{
				fader.GotoScene("tutorialScene");
			}
		}
	}	
}
