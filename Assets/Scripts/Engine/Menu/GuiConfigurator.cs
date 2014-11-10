using UnityEngine;
using System.Collections;

public class GuiConfigurator : MonoBehaviour
{
    void OnGUI()
    {
        GUI.skin.font = Resources.Load<Font>("Fonts/Petitinho");
        GUI.skin.button.fontSize = 18;
        GUI.skin.button.normal.background = Resources.Load<Texture2D>("Sprites/Buttons/btn");
        GUI.skin.button.hover.background = Resources.Load<Texture2D>("Sprites/Buttons/btnHover");
        GUI.skin.button.active.background = Resources.Load<Texture2D>("Sprites/Buttons/btnActive");
    }
}
