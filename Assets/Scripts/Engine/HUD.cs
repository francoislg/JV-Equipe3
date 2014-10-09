using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    public bool isPaused;
    public Rect pauseWindow;
    public Texture2D weaponIcon;
    public Texture2D powerUpIcon;
    public Texture2D healthIcon;

    void Start()
    {
        pauseWindow = new Rect(200, 50, 200, 100);
        // on pourra loader dynamiquement l'icone d'arme.
        weaponIcon = (Texture2D)Resources.Load("Sprites/slingshotIcon");
        powerUpIcon = (Texture2D)Resources.Load("Sprites/candyIcon");
        healthIcon = (Texture2D)Resources.Load("Sprites/orangeJuiceIcon");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            Time.timeScale = isPaused ? 0 : 1;
        }
    }
    
    void OnGUI()
    {
        if (!isPaused)
        {
            GUI.Box(new Rect(20, 20, 70, 70), "Level 1");
            GUI.Button(new Rect(30, 40, 50, 40), "Quit..."); //inside case 1

            GUI.Box(new Rect(Screen.width - 90, 20, 70, 70), weaponIcon);
            GUI.Box(new Rect(20, Screen.height - 90, 70, 70), powerUpIcon);
            GUI.Box(new Rect(Screen.width - 90, Screen.height - 90, 70, 70), healthIcon);
        }

        if (isPaused)
        {
            pauseWindow = GUI.Window(0, pauseWindow, renderWindow, "GAME PAUSED");
        }
    }


    void renderWindow(int windowID)
    {
        if (GUILayout.Button("Resume"))
        {
            isPaused = !isPaused;
            Time.timeScale = 1;
        }
    }
}
