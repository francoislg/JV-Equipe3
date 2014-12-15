using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int Height = 25;
    const int Width = 250;
    const int Margin = 10;

    static public int Score = 0;

    public float Level = 1;
    public float attack;
    public float speed
    {
        get { return _speed + (_inventory ? _inventory.speed : 0); }
        protected set { _speed = value; }
    }
    
    GameObject _go;
    HudScore _hudScore;
    PlayerHasInventory _inventory;
    private float _speed;
    Rect _statusZone;

    void Start()
    {
        _go = GameObject.Find("GameController");
        _hudScore = (HudScore)_go.GetComponent(typeof(HudScore));
        _inventory = GetComponent<PlayerHasInventory>() as PlayerHasInventory;

        _statusZone = new Rect(Screen.width - Margin - Width, Margin, Width, Height);
    }

    void Update()
    {
        if (Score > 100 * Level)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        attack += 0.5f;
        speed += 0.1f;
    }

    public void AddPointsToScore(int points)
    {
        Score += points;
        _hudScore.PlayerScore = Score;
    }

    void OnGUI()
    {
        GUI.Label(_statusZone, "Level : " + Level + "  Speed : " + speed);
    }
}
