using UnityEngine;
using System.Collections;

public class DonneBonusSpecial : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHasWeapon joueur = other.gameObject.GetComponent("PlayerHasWeapon") as PlayerHasWeapon;
            joueur.giveBonusSpecial();
            Destroy(gameObject);
        }
    }
}
