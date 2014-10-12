using UnityEngine;
using System.Collections;

public class PlayerHasLife : HasLife
{
    private HudLife hudLife;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            hudLife = gameControllerObject.GetComponent<HudLife>();
        }
    }

    public override void receiveDamage(int damage) {
        life -= damage;
        hudLife.UpdateLifeBar(life);
        if (life <= 0) {
            // Do something
        }
    }
}
