using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    public Rect pauseWindow;
    public Texture2D weaponIcon;
    public Texture2D powerUpIcon;
    public Texture2D healthIcon;

    void Start()
    {
        InitPauseWindow();
        InitSprites();
    }

    void InitPauseWindow()
    {
        int pauseW = 250;
        int pauseH = 100;
        pauseWindow = new Rect(Screen.width / 2 - pauseW / 2, Screen.height / 2 - pauseH / 2, pauseW, pauseH);
    }

    void InitSprites()
    {
        // on pourra loader dynamiquement l'icone d'arme.
        weaponIcon = (Texture2D)Resources.Load("Sprites/slingshotIcon");
        powerUpIcon = (Texture2D)Resources.Load("Sprites/candyIcon");
        healthIcon = (Texture2D)Resources.Load("Sprites/orangeJuiceIcon");
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
            GUI.Box(new Rect(20, 20, 70, 70), "Level 1");
            GUI.Button(new Rect(30, 40, 50, 40), "Quit..."); //inside case 1

            GUI.Box(new Rect(Screen.width - 90, 20, 70, 70), weaponIcon);
            GUI.Box(new Rect(20, Screen.height - 90, 70, 70), powerUpIcon);
            GUI.Box(new Rect(Screen.width - 90, Screen.height - 90, 70, 70), healthIcon);
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
