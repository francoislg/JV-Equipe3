using UnityEngine;


public class MainMenu : MonoBehaviour
{
    const int buttonWidth = 200;
    const int buttonHeight = 60;
    const int margin = 10;

    Rect playButton;
    Rect helpButton;
    ScreenFader fader;

    void Start()
    {
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        playButton = new Rect(
            (Screen.width / 2) - (buttonWidth / 2),
            (Screen.height / 2) - (buttonHeight / 2),
            buttonWidth,
            buttonHeight
        );

        helpButton = new Rect(
            playButton.xMin,
            playButton.yMax + margin,
            buttonWidth,
            buttonHeight
        );
    }

    void OnGUI()
    {
        if (!fader.SceneEnding && !fader.SceneStarting)
        {
            if (GUI.Button(playButton, "Jouer !"))
            {
                fader.GotoScene("GameScene");
            }
            else if (GUI.Button(helpButton, "A propos ..."))
            {
                fader.GotoScene("AboutScene");
            }
        }
    }
}