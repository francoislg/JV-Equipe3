using UnityEngine;
using System.Collections;

public class GuiConfigurator : MonoBehaviour
{
    public GUIStyle windowStyle;
    public GUIStyle buttonStyle;

    void OnGUI()
    {
        GUI.skin.font = Resources.Load<Font>("Fonts/Petitinho");
        GUI.skin.button = buttonStyle;
        GUI.skin.window = windowStyle;
    }
}
