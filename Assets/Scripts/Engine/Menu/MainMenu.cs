using UnityEngine;


public class MainMenu : MonoBehaviour
{
    private const int buttonWidth = 150;
    private const int buttonHeight = 60;
    private const int margin = 10;

    private Rect playButton;
    private Rect helpButton;

    private ScreenFader fader;

    void Start()
    {
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        playButton = new Rect(
            20,
            (Screen.height / 3) - (buttonHeight / 2),
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