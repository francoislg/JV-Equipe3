using UnityEngine;
using System.Collections;

public class HudStatus : MonoBehaviour
{
    const int height = 25;
    const int width = 350;
    const int margin = 10;

	public int playerLevel = 1;
    public int attackBonus = 1;
    public int speedBonus = 1;
	
	Rect statusZone;

    void Start()
    {		
		statusZone = new Rect(Screen.width - margin - width, margin, width, height);
    }

    void OnGUI()
    {
		GUI.TextArea(statusZone, "Level : " + playerLevel + "  Attack : " + attackBonus + "  Speed : " + speedBonus);
    }

}
