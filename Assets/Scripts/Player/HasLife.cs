using UnityEngine;
using System.Collections;

public class HasLife : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            life -= Random.Range(1, 15);
            hudLife.UpdateLifeBar(life);
        }
    }
}
