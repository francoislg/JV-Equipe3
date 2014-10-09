using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    public Texture2D weaponIcon;
    public Texture2D powerUpIcon;
    public Texture2D healthIcon;

    private const int ICON_SIZE = 70;
    private const int SCREEN_MARGIN = 20;
    private Rect pauseWindow;
    private Rect powerUpPosition;
    private Rect weaponPosition;
    private Rect healthPosition;

    void Start()
    {
        InitSprites();
        InitAttributes();
    }

    void InitAttributes()
    {
        int pauseW = 250;
        int pauseH = 100;
        pauseWindow = new Rect(Screen.width / 2 - pauseW / 2, Screen.height / 2 - pauseH / 2, pauseW, pauseH);

        weaponPosition = new Rect(
            SCREEN_MARGIN,
            Screen.height - ICON_SIZE - SCREEN_MARGIN,
            ICON_SIZE,
            ICON_SIZE);
        powerUpPosition = new Rect(
            SCREEN_MARGIN + ICON_SIZE + 20,
            Screen.height - ICON_SIZE - SCREEN_MARGIN, 
            ICON_SIZE, 
            ICON_SIZE);
        healthPosition = new Rect(
            Screen.width - ICON_SIZE - SCREEN_MARGIN,
            Screen.height - ICON_SIZE - SCREEN_MARGIN, 
            ICON_SIZE, 
            ICON_SIZE);
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
            GUI.Box(weaponPosition, weaponIcon);
            GUI.Box(powerUpPosition, powerUpIcon);
            GUI.Box(healthPosition, healthIcon);
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
