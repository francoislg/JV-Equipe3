using UnityEngine;
using System.Collections;

public class HudLife : MonoBehaviour
{
    const int iconSize = 70;
    const int screenMargin = 20;

    Texture2D hudLifeBackground;
    Texture2D hudLifeBar;
    Rect hudLifeBackgroundPosition;
    Rect hudLifeBarPosition;
    float hudLifeBarMaxHeight;

    void Start()
    {
        // Load and positionate hud life background
        hudLifeBackground = (Texture2D)Resources.Load("Sprites/hudLifeEmpty");
        hudLifeBackgroundPosition = new Rect(
            Screen.width - iconSize - screenMargin,   // LEFT
            Screen.height - iconSize - screenMargin,  // TOP
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
        hudLifeBarPosition.yMin = hudLifeBarPosition.yMax - (Mathf.Clamp(pctLife, 0, 1) * hudLifeBarMaxHeight);
    }

    void OnGUI()
    {
        GUI.DrawTexture(hudLifeBackgroundPosition, hudLifeBackground);
        GUI.DrawTexture(hudLifeBarPosition, hudLifeBar);
    }
}
