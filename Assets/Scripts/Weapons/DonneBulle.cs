using UnityEngine;
using System.Collections;

public class DonneBulle : DonneItem {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && init)
        {
            base.OnTriggerEnter(other);
            joueur.GiveWeapon(2);
            Destroy(this.gameObject);
        }
    }
}
