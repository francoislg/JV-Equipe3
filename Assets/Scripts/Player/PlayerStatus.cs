using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int Height = 25;
    const int Width = 250;
    const int Margin = 10;

    static public int Score = 0;

    public float Level = 1;
    public float Attack;
    public float Speed
    {
        get { return _speed + (_inventory ? _inventory.SpeedBonus : 0); }
        protected set { _speed = value; }
    }
    
    HudScore _hudScore;
    PlayerHasInventory _inventory;
    private float _speed;
    Rect _statusZone;

    void Start()
    {
        var go = GameObject.Find("GameController");
        _hudScore = (HudScore)go.GetComponent(typeof(HudScore));
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
        Attack += 0.5f;
        Speed += 0.1f;
    }

    public void AddPointsToScore(int points)
    {
        Score += points;
        _hudScore.PlayerScore = Score;
    }

    void OnGUI()
    {
        GUI.Label(_statusZone, "Level : " + Level + "  Speed : " + Speed);
    }
}
