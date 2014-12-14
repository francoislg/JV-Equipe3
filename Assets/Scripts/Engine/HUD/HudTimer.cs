using UnityEngine;
using System.Collections;

public class HudTimer : MonoBehaviour
{
    const int Height = 25;
    const int Width = 120;
    const int TopMargin = 10;

    readonly int _leftRightMargin = (Screen.width / 2) - 60;

    Rect _timerZone;

    void Start()
    {
		_timerZone = new Rect(_leftRightMargin, TopMargin, Width, Height);
    }

	void OnGUI()
	{
		GUI.Label(_timerZone, "Time : " + Mathf.Round(Time.timeSinceLevelLoad));
	}

}
