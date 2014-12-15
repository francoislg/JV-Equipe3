using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int Height = 25;
    const int Width = 250;
    const int Margin = 10;

    static public int Score = 0;

    public float Level;
    public float Attack;
    public float Speed
    {
        get { return _speed + (_inventory ? _inventory.SpeedBonus : 0); }
        protected set { _speed = value; }
    }
    
    PlayerHasInventory _inventory;
    private float _speed;
    Rect _statusZone;
    Rect _scoreZone;

    void Start()
    {
        Level = 1;
        Attack = 0;
        Speed = 0;
        Score = 0;

        _inventory = GetComponent<PlayerHasInventory>();

        _statusZone = new Rect(Screen.width - Margin - Width, Margin, Width, Height);
        _scoreZone = new Rect(Margin, Margin, Width, Height);
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
        Attack += 1.5f;
        Speed += 1f;
    }

    void OnGUI()
    {
        GUI.Label(_statusZone, "Level : " + Level + "  Speed : " + Speed);
        GUI.Label(_scoreZone, "Score : " + Score);
    }
}
