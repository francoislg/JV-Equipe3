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
        base.receiveDamage(damage);
        hudLife.UpdateLifeBar(life / maximumLife);
    }

    public override void onDeath() {
        respawn();
    }

    public void respawn() {
        life = maximumLife;
    }
}
