using UnityEngine;
using System.Collections;

public class DonneBallon : DonneItem {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && init)
        {
            base.OnTriggerEnter(other);
            joueur.GiveWeapon(1);
            Destroy(this.gameObject);
        }
    }


}
