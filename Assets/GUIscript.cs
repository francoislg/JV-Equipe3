using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {

	public bool isPause;
	public Rect pauseWindow; 
	public Texture2D weaponIcon;
	public Texture2D powerUpIcon;
	public Texture2D healthIcon;
	// Use this for initialization
	void Start () {
		pauseWindow = new Rect(200,50,200,100);
		// on pourra loader dynamiquement l'icone d'arme.
		weaponIcon = (Texture2D)Resources.Load("slingshotIcon");
		powerUpIcon = (Texture2D)Resources.Load("candyIcon");
		healthIcon = (Texture2D)Resources.Load("orangeJuiceIcon");
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Input.GetKeyDown(KeyCode.Escape)) {
			isPause = !isPause;
				
			if(isPause)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}

	}

	void OnGUI () {

		if (!isPause) {
			GUI.Box(new Rect(20,20,70,70), "Level 1");
			GUI.Button(new Rect(30,40,50,40), "Quit..."); //inside case 1
			
			//GUI.Box(new Rect(Screen.width - 90,20,70,70), "Case 2");
			GUI.Box(new Rect(Screen.width - 90,20,70,70), weaponIcon);

			//GUI.Box(new Rect(20,Screen.height - 90,70,70), "Case 3");
			GUI.Box(new Rect(20,Screen.height - 90,70,70), powerUpIcon);

			//GUI.Box(new Rect(Screen.width - 90,Screen.height - 90,70,70), "Case 4");
			GUI.Box(new Rect(Screen.width - 90,Screen.height - 90,70,70), healthIcon);
		}


		if(isPause) 
			pauseWindow = GUI.Window(0, pauseWindow, renderWindow, "GAME PAUSED");


	}


	void renderWindow(int windowID) {
		if (GUILayout.Button ("Resume")) {
			isPause = !isPause;
			Time.timeScale = 1;
		}
	}
}
