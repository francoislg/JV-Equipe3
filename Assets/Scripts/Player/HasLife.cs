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
            // Si l'objet est en colision avec un objet tagué Enemy
            // Alors on descent sa vie
            DecreaseLife(other.gameObject);
            
            // Puis on met a jour le HUD
            hudLife.UpdateLifeBar(life);
        }
    }

    private void DecreaseLife(GameObject enemy)
    {
        // On regarde si l'enemy a un composant MakeDamage
        MakeDamange makeDamageComponent = enemy.GetComponent<MakeDamange>();
        if (makeDamageComponent != null)
        {
            // Si oui, alors on regarde directement la valeur assigné à l'ennemi
            life -= makeDamageComponent.damageCount;
            Debug.Log("Decrease life of : " + makeDamageComponent.damageCount);
        }
        else
        {
            // Si non on baisse les PV au hasard
            life -= Random.Range(1, 15);
            Debug.Log("Decrease life of random value.");
        }
    }
}
