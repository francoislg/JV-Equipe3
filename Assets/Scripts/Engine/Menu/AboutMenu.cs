using UnityEngine;
using System.Collections;

public class AboutMenu : MonoBehaviour
{
    const int buttonWidth = 350;
    const int buttonHeight = 60;
    const int margin = 10;

    Rect backButton;
    ScreenFader fader;

    void Start()
    {
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        backButton = new Rect(
            (Screen.width / 2) - (buttonWidth / 2),
            Screen.height - buttonHeight - margin,
            buttonWidth,
            buttonHeight
        );
    }

    void OnGUI()
    {
        if (!fader.SceneEnding && !fader.SceneStarting)
        {
            if (GUI.Button(backButton, "Retour au menu principal"))
            {
                fader.GotoScene("MenuScene");
            }
        }
    }
}
