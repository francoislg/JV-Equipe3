using UnityEngine;
using System.Collections;

public class PlayerHasLife : MonoBehaviour
{
    private HudLife hudLife;
    private int life = 100;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            hudLife = gameControllerObject.GetComponent<HudLife>();
        }
    }

    public void ReceiveDamage(int damage) {
        life -= damage;
        hudLife.UpdateLifeBar(life);
        if (life <= 0) {
            // Do something
        }
    }
}
