using UnityEngine;
using System.Collections;

public class DealsDamageToPlayerOnHit : MonoBehaviour {
    public int damageCount = 10;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlayerHasLife playerLife = other.GetComponent<PlayerHasLife>() as PlayerHasLife;
            playerLife.receiveDamage(damageCount);
        }
    }
}
