using UnityEngine;
using System.Collections;

public class HudScore : MonoBehaviour
{
	public int playerScore = 0;
	const int height = 25;
	const int width = 200;
	const int margin = 10;
	int level = 1;

	Rect scoreZone;


    void Start()
    {
		scoreZone = new Rect(margin, margin, width, height);
    }

    void Update()
    {
		if (playerScore > 100 * level) {

			GameObject go = GameObject.Find("GameController");
			HudStatus status = (HudStatus) go.GetComponent(typeof(HudStatus));
			status.levelUp();
			level++;
		}

    }

	void OnGUI()
	{
		GUI.TextArea(scoreZone, "Score : " + playerScore);
	}

	public void addToScore(int score) {
		playerScore += score;
	}
}
