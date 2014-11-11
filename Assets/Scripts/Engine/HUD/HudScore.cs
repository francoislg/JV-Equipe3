using UnityEngine;
using System.Collections;

public class HudScore : MonoBehaviour
{
	public int playerScore = 0;
	const int height = 25;
	const int width = 200;
	const int margin = 10;

	Rect scoreZone;


    void Start()
    {
		scoreZone = new Rect(margin, margin, width, height);
    }

    void Update()
    {
		
    }

	void OnGUI()
	{
		GUI.TextArea(scoreZone, "Score : " + playerScore);
	}

	public void addToScore(int score) {
		playerScore += score;
	}
}
