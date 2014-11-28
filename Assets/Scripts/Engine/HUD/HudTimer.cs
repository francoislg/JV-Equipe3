using UnityEngine;
using System.Collections;

public class HudTimer : MonoBehaviour
{

	int height = 25;
	int width = 120;
	int leftRightMargin = (Screen.width / 2) - 60;
	int topMargin = 10;

	Rect timerZone;

    void Start()
    {
		timerZone = new Rect(leftRightMargin, topMargin, width, height);
    }

	void OnGUI()
	{
		GUI.TextArea(timerZone, "Time : " + Mathf.Round(Time.timeSinceLevelLoad));
	}

}
