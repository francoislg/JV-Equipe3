using UnityEngine;
using System.Collections;

public class HudTimer : MonoBehaviour
{
    const int Height = 25;
    const int Width = 120;
    const int TopMargin = 10;

    Rect _timerZone;

    void Start()
    {
        _timerZone = new Rect(
            left: (Screen.width / 2) - 60,
            top: TopMargin,
            width: Width,
            height: Height
            );
    }

    void OnGUI()
    {
        GUI.Label(_timerZone, "Time : " + Mathf.Round(Time.timeSinceLevelLoad));
    }

}
