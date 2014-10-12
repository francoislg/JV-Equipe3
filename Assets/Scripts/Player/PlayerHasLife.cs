using UnityEngine;
using System.Collections;

public class PlayerHasLife : HasLife
{
    private HudLife hudLife;
    private float maximumLife = 100; 

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            hudLife = gameControllerObject.GetComponent<HudLife>();
        }
        life = maximumLife;
    }

    public override void receiveDamage(float damage) {
        life -= damage;
        if (life <= 0) {
            respawn();
        }

        hudLife.UpdateLifeBar(life / maximumLife);
    }

    public void respawn() {
        life = maximumLife;
    }
}
