using UnityEngine;

public class MainMenu : MonoBehaviour
{
    const int ButtonWidth = 200;
    const int ButtonHeight = 60;
    const int Margin = 10;

    public AudioClip NewGameVoice;

    Rect _playButton;
    Rect _helpButton;
    ScreenFader _fader;

    void Start()
    {
        _fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }

    void Update()
    {
        _playButton = new Rect(
            (Screen.width / 2) - (ButtonWidth / 2),
            (Screen.height / 2) - (ButtonHeight / 2),
            ButtonWidth,
            ButtonHeight
        );

        _helpButton = new Rect(
            _playButton.xMin,
            _playButton.yMax + Margin,
            ButtonWidth,
            ButtonHeight
        );
    }

    void OnGUI()
    {
        if (_fader.SceneEnding || _fader.SceneStarting) return;

        if (GUI.Button(_playButton, "Jouer !"))
        {
            AudioSource.PlayClipAtPoint(NewGameVoice, Camera.main.transform.position);
            System.Threading.Thread.Sleep(2000);
            _fader.GotoScene("HistoryScene");

        }
        else if (GUI.Button(_helpButton, "A propos ..."))
        {
            _fader.GotoScene("AboutScene");
        }
    }
}


