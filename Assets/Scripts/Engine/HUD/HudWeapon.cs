using UnityEngine;
using System.Collections;

public class HudWeapon : MonoBehaviour
{
    const int iconSize = 70;
    const int screenMargin = 20;

    public Texture2D weaponIcon;
    public Texture2D powerUpIcon;

    Rect pauseWindow;
    Rect powerUpPosition;
    Rect weaponPosition;

    void Start()
    {
        int pauseW = 250;
        int pauseH = 100;
        pauseWindow = new Rect(Screen.width / 2 - pauseW / 2, Screen.height / 2 - pauseH / 2, pauseW, pauseH);

        weaponPosition = new Rect(
            screenMargin,
            Screen.height - iconSize - screenMargin,
            iconSize,
            iconSize);
        powerUpPosition = new Rect(
            screenMargin + iconSize + 20,
            Screen.height - iconSize - screenMargin,
            iconSize,
            iconSize);


        // on pourra loader dynamiquement l'icone d'arme.
        weaponIcon = (Texture2D)Resources.Load("Sprites/slingshotIcon");
        powerUpIcon = (Texture2D)Resources.Load("Sprites/candyIcon");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = (Time.timeScale + 1) % 2;
        }
    }

    void OnGUI()
    {
        if (Time.timeScale > 0)
        {
            GUI.Box(weaponPosition, weaponIcon);
            GUI.Box(powerUpPosition, powerUpIcon);
        }
        else
        {
            pauseWindow = GUI.Window(0, pauseWindow, RenderWindow, "GAME PAUSED");
        }
    }


    void RenderWindow(int windowID)
    {
        if (GUILayout.Button("Resume"))
        {
            Time.timeScale = 1;
        }
    }
}
