using UnityEngine;
using System.Collections;

public class HudStatus : MonoBehaviour
{
    const int height = 25;
    const int width = 350;
    const int margin = 10;

	public float playerLevel = 0;
    public float attackBonus = 0;
    public float speedBonus = 0;
	
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
