using UnityEngine;
using System.Collections;

public class DonneSlingshot : DonneItem {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && init)
        {
            base.OnTriggerEnter(other);
            joueur.GiveWeapon(0);
            Destroy(this.gameObject);
        }
    }
}
