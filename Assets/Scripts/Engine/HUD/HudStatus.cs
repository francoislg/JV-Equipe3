using UnityEngine;
using System.Collections;

public class HudStatus : MonoBehaviour
{
    const int Height = 25;
    const int Width = 250;
    const int Margin = 10;

    public float playerLevel = 0;
    public float speedBonus = 0;

    Rect _statusZone;

    private void Start()
    {
		speedBonus = 0;
        _statusZone = new Rect(Screen.width - Margin - Width, Margin, Width, Height);
    }

    void OnGUI()
    {
        GUI.Label(_statusZone, "Level : " + playerLevel + "  Speed : " + speedBonus);
    }

}
