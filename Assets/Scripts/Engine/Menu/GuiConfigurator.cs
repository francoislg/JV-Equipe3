using UnityEngine;
using System.Collections;

public class GuiConfigurator : MonoBehaviour
{

    void OnGUI()
    {
        GUI.skin.font = Resources.Load<Font>("Fonts/pricedown");
        GUI.skin.button.fontSize = 25;
        GUI.skin.button.normal.background = Resources.Load<Texture2D>("Sprites/Buttons/btn");
        GUI.skin.button.hover.background = Resources.Load<Texture2D>("Sprites/Buttons/btnHover");
        GUI.skin.button.active.background = Resources.Load<Texture2D>("Sprites/Buttons/btnActive");
    }
}
