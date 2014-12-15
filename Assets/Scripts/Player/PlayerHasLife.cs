using UnityEngine;

public class PlayerHasLife : MonoBehaviour, HasLife
{
    const int IconSize = 64;
    const int ScreenMargin = 20;

    public float Life
    {
        get { return _life; }
        set { _life = Mathf.Clamp(value, 0, maximumLife); }
    }
    public float maximumLife = 10;
    public AudioClip sndOnDeath;

    Texture2D _hudLifeBackground;
    Texture2D _hudLifeBar;
    Rect _hudLifeBackgroundPosition;
    Rect _hudLifeBarPosition;
    float _hudLifeBarMaxHeight;
    ScreenFader _fader;
    float _life = 10;

    void Start()
    {
        Life = maximumLife;

        ConfigureLifeBar();
        _fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
    }

    void ConfigureLifeBar()
    {
        // Load and positionate hud life background
        _hudLifeBackground = (Texture2D)Resources.Load("Sprites/hudLifeEmpty");
        _hudLifeBackgroundPosition = new Rect(
            left: Screen.width - IconSize - ScreenMargin,
            top: Screen.height - IconSize - ScreenMargin,
            width: _hudLifeBackground.width,
            height: _hudLifeBackground.height
        );

        // Load and positionate hud life progress bar
        // Sorry, this is some magic value du to hudLifeBar sprite itself
        _hudLifeBar = (Texture2D)Resources.Load("Sprites/hudLifeBar");
        _hudLifeBarPosition = new Rect(_hudLifeBackgroundPosition);
        _hudLifeBarPosition.xMin += 4;
        _hudLifeBarPosition.yMax -= 5;
        _hudLifeBarPosition.xMax -= 5;
        _hudLifeBarPosition.yMin += 14;

        _hudLifeBarMaxHeight = _hudLifeBarPosition.height;
    }

    public void ReceiveDamage(float damage)
    {
        if (Life <= 0) return;

        Life -= damage;
        if (Life <= 0)
        {
            OnDeath();
        }
        UpdateLifeBar(Life / maximumLife);
    }

    public void ReceiveBonus(float bonus)
    {
        if (Life <= 0) return;

        Life += bonus;
        UpdateLifeBar(Life / maximumLife);
    }

    public void OnDeath()
    {
        AudioSource.PlayClipAtPoint(sndOnDeath, Camera.main.transform.position);
        System.Threading.Thread.Sleep(1300);

        EndGameMenu.FinalScore = PlayerStatus.Score;
        _fader.GotoScene("EndGameScene");
    }

    public void UpdateLifeBar(float pctLife)
    {
        _hudLifeBarPosition.yMin = _hudLifeBarPosition.yMax - (Mathf.Clamp(pctLife, 0, 1) * _hudLifeBarMaxHeight);
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
        GUI.DrawTexture(_hudLifeBackgroundPosition, _hudLifeBackground);
        GUI.DrawTexture(_hudLifeBarPosition, _hudLifeBar);
    }
}
