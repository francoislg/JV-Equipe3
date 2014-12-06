using UnityEngine;
using System.Collections;

public class DonneBonusSpeed : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHasWeapon joueur = other.gameObject.GetComponent("PlayerHasWeapon") as PlayerHasWeapon;
            joueur.giveBonusSpeed();
            Destroy(gameObject);
        }
    }
}
