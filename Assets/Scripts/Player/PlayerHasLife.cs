﻿using UnityEngine;
using System.Collections;

public class PlayerHasLife : HasLife
{
    private GameObject gameControllerObject;
    private HudLife hudLife;
    private float maximumLife = 100;

    void Start()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            hudLife = gameControllerObject.GetComponent<HudLife>();
        }
        life = maximumLife;
    }

    public override void ReceiveDamage(float damage)
    {
        base.ReceiveDamage(damage);
        hudLife.UpdateLifeBar(life / maximumLife);
    }

    public override void OnDeath()
    {
        gameControllerObject.GetComponent<Restarter>().RestartGame();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EndPoint")
        {
            gameControllerObject.GetComponent<Restarter>().RestartGame();
        }
    }
}
