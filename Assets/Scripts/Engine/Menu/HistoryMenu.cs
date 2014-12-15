using UnityEngine;

public class HistoryMenu : MonoBehaviour
{
    static public bool HardDifficulty = false;

    const int ButtonWidth = 200;
    const int ButtonHeight = 60;
    const int Margin = 10;

    Rect _playButton;
    Rect _playHardButton;
    Rect _tutoButton;
    ScreenFader _fader;

    void Start()
    {
        _fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }

    void Update()
    {
        _playButton = new Rect(
            (Screen.width / 3) - (ButtonWidth / 2),
            (Screen.height / 4) - (ButtonHeight / 4),
            ButtonWidth,
            ButtonHeight
            );

        _playHardButton = new Rect(
            2 * (Screen.width / 3) - (ButtonWidth / 2),
            (Screen.height / 4) - (ButtonHeight / 4),
            ButtonWidth,
            ButtonHeight
            );


        _tutoButton = new Rect(
            (Screen.width / 2) - (ButtonWidth / 2),
            _playButton.yMax + Margin,
            ButtonWidth,
            ButtonHeight
            );
    }

    void OnGUI()
    {
        if (_fader.SceneEnding || _fader.SceneStarting) return;

        if (GUI.Button(_playButton, "Commencer l'aventure !"))
        {
            _fader.GotoScene("GameScene");
        }
        else if (GUI.Button(_playHardButton, "Commencer au mode difficile"))
        {
            HardDifficulty = true;
            _fader.GotoScene("GameScene");
        }
        else if (GUI.Button(_tutoButton, "Commencer au niveau tutoriel"))
        {
            _fader.GotoScene("tutorialScene");
        }
    }
}
