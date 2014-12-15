using UnityEngine;
using System.Collections;

public class HudScore : MonoBehaviour
{
	public int PlayerScore = 0;

	const int Height = 25;
	const int Width = 200;
	const int Margin = 10;

	Rect _scoreZone;

    void Start()
    {
		_scoreZone = new Rect(Margin, Margin, Width, Height);
    }

	void OnGUI()
	{
		GUI.Label(_scoreZone, "Score : " + PlayerScore);
	}

}
