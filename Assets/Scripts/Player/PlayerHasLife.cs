using UnityEngine;
using System.Collections;

public class PlayerHasLife : MonoBehaviour, HasLife
{
    const int iconSize = 64;
    const int screenMargin = 20;

	protected float life;
	public float maximumLife = 10;

	private bool isAlive = true;

	public AudioClip sndOnDeath;

    Texture2D hudLifeBackground;
    Texture2D hudLifeBar;
    Rect hudLifeBackgroundPosition;
    Rect hudLifeBarPosition;
    float hudLifeBarMaxHeight;

	ScreenFader fader;

	void Start(){
		life = maximumLife;
		ConfigureLifeBar();
		fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
	}

	void ConfigureLifeBar()
    {
        // Load and positionate hud life background
        hudLifeBackground = (Texture2D)Resources.Load("Sprites/hudLifeEmpty");
        hudLifeBackgroundPosition = new Rect(
            Screen.width - iconSize - screenMargin,   // LEFT
            Screen.height - iconSize - screenMargin,  // TOP
            hudLifeBackground.width,                    // WIDTH
            hudLifeBackground.height                    // HEIGHT
        );

        // Load and positionate hud life progress bar
        // Sorry, this is some magic value du to hudLifeBar sprite itself
        hudLifeBar = (Texture2D)Resources.Load("Sprites/hudLifeBar");
        hudLifeBarPosition = new Rect(hudLifeBackgroundPosition);
        hudLifeBarPosition.xMin += 4;
        hudLifeBarPosition.yMax -= 5;
        hudLifeBarPosition.xMax -= 5;
        hudLifeBarPosition.yMin += 14;

        hudLifeBarMaxHeight = hudLifeBarPosition.height;
    }

    public void ReceiveDamage(float damage)
    {
		if(isAlive){
			life -= damage;
			if (life <= 0)
			{
				isAlive = false;
				OnDeath();
			}
	        UpdateLifeBar(life / maximumLife);
		}
    }

    public void ReceiveBonus(float bonus)
    {
		if(isAlive){
	        life += bonus;
	        if (life > maximumLife)
	        {
	            life = maximumLife;
	        }
	        UpdateLifeBar(life / maximumLife);
		}
    }

    public void OnDeath()
    {
		AudioSource.PlayClipAtPoint(sndOnDeath, Camera.main.transform.position);
		System.Threading.Thread.Sleep(1300);
        
		//GameObject.FindObjectOfType<Restarter>().RestartGame();
		EndGameMenu.finalScore = PlayerStatus.score;
		fader.GotoScene("EndGameScene");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EndPoint")
        {
            GameObject.FindObjectOfType<Restarter>().RestartGame();
        }
    }

    public void UpdateLifeBar(float pctLife)
    {
        // Compute new yMin value
        // Uses percent of life to fill life bar
        hudLifeBarPosition.yMin = hudLifeBarPosition.yMax - (Mathf.Clamp(pctLife, 0, 1) * hudLifeBarMaxHeight);
    }

	public void PushFromSource(Vector3 source, float force)
	{
		Vector3 direction = transform.position - source;
		direction.y = 0;
		direction.Normalize();
		direction *= force * 300;
		rigidbody.AddForce(direction, ForceMode.Acceleration);
	}

    void OnGUI()
    {
        GUI.DrawTexture(hudLifeBackgroundPosition, hudLifeBackground);
        GUI.DrawTexture(hudLifeBarPosition, hudLifeBar);
    }
}
