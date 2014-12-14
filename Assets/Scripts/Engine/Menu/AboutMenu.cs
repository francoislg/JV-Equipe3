using UnityEngine;

public class AboutMenu : MonoBehaviour
{
    const int ButtonWidth = 350;
    const int ButtonHeight = 60;
    const int Margin = 10;

    Rect _backButton;
    ScreenFader _fader;

    void Start()
    {
        _fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }

    void Update()
    {
        _backButton = new Rect(
                (Screen.width / 2) - (ButtonWidth / 2),
                Screen.height - ButtonHeight - Margin,
                ButtonWidth,
                ButtonHeight
            );
    }

    void OnGUI()
    {
        if (_fader.SceneEnding || _fader.SceneStarting) return;

        if (GUI.Button(_backButton, "Retour au menu principal"))
        {
            _fader.GotoScene("MenuScene");
        }
    }
}
