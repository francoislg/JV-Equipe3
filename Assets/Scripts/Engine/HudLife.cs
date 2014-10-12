using UnityEngine;
using System.Collections;

public class HudLife : MonoBehaviour
{
    private const int ICON_SIZE = 70;
    private const int SCREEN_MARGIN = 20;

    private Texture2D hudLifeBackground;
    private Rect hudLifeBackgroundPosition;

    private Texture2D hudLifeBar;
    private Rect hudLifeBarPosition;
    private float hudLifeBarMaxHeight;

    void Start()
    {
        // Load and positionate hud life background
        hudLifeBackground = (Texture2D)Resources.Load("Sprites/hudLifeEmpty");
        hudLifeBackgroundPosition = new Rect(
            Screen.width - ICON_SIZE - SCREEN_MARGIN,   // LEFT
            Screen.height - ICON_SIZE - SCREEN_MARGIN,  // TOP
            hudLifeBackground.width,                    // WIDTH
            hudLifeBackground.height                    // HEIGHT
        );

        // Load and positionate hud life progress bar
        // Sorry, this is some magic value du to hudLifeBar sprite itself
        hudLifeBar = (Texture2D)Resources.Load("Sprites/hudLifeBar");
        hudLifeBarPosition = new Rect(hudLifeBackgroundPosition);
        hudLifeBarPosition.xMin += 4;
        hudLifeBarPosition.yMax -= 5;
        hudLifeBarPosition.xMax -= 5;
        hudLifeBarPosition.yMin += 14;

        hudLifeBarMaxHeight = hudLifeBarPosition.height;
    }

    public void UpdateLifeBar(float pctLife)
    {       
        // Compute new yMin value
        // Uses percent of life to fill life bar
        Debug.Log(pctLife);
        hudLifeBarPosition.yMin = hudLifeBarPosition.yMax - (Mathf.Clamp(pctLife, 0, 1) * hudLifeBarMaxHeight);
    }

    void OnGUI()
    {
        GUI.DrawTexture(hudLifeBackgroundPosition, hudLifeBackground);
        GUI.DrawTexture(hudLifeBarPosition, hudLifeBar);
    }
}
