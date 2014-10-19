using UnityEngine;
using System.Collections;

public class PlayerHasLife : HasLife
{
    private GameObject gameControllerObject;
    private HudLife hudLife;
    private float maximumLife = 100; 

    void Start()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            hudLife = gameControllerObject.GetComponent<HudLife>();
        }
        life = maximumLife;
    }

    public override void receiveDamage(float damage) {
        base.receiveDamage(damage);
        hudLife.UpdateLifeBar(life / maximumLife);
    }

    public override void onDeath() {
        restart();
    }

    private void setLife(float life) {
        this.life = life;
        hudLife.UpdateLifeBar(this.life / maximumLife);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "EndPoint") {
            restart();
        }
    }

    private void restart() {
        Restarter restart = gameControllerObject.GetComponent<Restarter>();
        restart.restartGame();
    }


    public void respawn() {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        transform.position = spawnPoint.transform.position;
        setLife(maximumLife);
    }
}
