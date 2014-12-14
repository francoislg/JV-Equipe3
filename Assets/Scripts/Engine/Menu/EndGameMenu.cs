using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    static public int finalScore = 0;

    const int ButtonWidth = 200;
    const int ButtonHeight = 60;
    const int ScoreZoneWidth = 250;
    const int ScoreZoneHeight = 25;
    const int Margin = 10;

    Rect _statusZone;
    Rect _menuButton;
    ScreenFader _fader;

    void Start()
    {
        _fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }

    void Update()
    {
        _statusZone = new Rect(Screen.width / 2 - ScoreZoneWidth / 2, (Screen.height / 2) - (ButtonHeight / 2), ScoreZoneWidth, ScoreZoneHeight);

        _menuButton = new Rect(
            (Screen.width / 2) - (ButtonWidth / 2),
            Screen.height - ButtonHeight - Margin,
            ButtonWidth,
            ButtonHeight
            );
    }

    void OnGUI()
    {
        if (_fader.SceneEnding || _fader.SceneStarting) return;

        GUI.TextArea(_statusZone, "Final score : " + finalScore);

        if (GUI.Button(_menuButton, "Retour au menu principal"))
        {
            _fader.GotoScene("MenuScene");
        }
    }
}
