using UnityEngine;
using System.Collections;

public abstract class DonneItem : MonoBehaviour {

    public GameObject itemBallon;
    public GameObject itemSlingshot;
    public GameObject itemBulle;
    public bool init = false;

    protected PlayerHasWeapon joueur;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && init)
        {
            joueur = other.gameObject.GetComponent("PlayerHasWeapon") as PlayerHasWeapon;
            int weapon = joueur.currentWeapon;
            GameObject copie;

            switch (weapon)
            {
                case 0 :
                        copie = MonoBehaviour.Instantiate(itemSlingshot, this.transform.position, this.transform.rotation) as GameObject;
                        DonneSlingshot slingshot = copie.GetComponent(typeof(DonneSlingshot)) as DonneSlingshot;
                        slingshot.init = false;
                        break;

                case 1:
                        copie = MonoBehaviour.Instantiate(itemBallon, this.transform.position, this.transform.rotation) as GameObject;
                        DonneBallon ballon = copie.GetComponent(typeof(DonneBallon)) as DonneBallon;
                        ballon.init = false;
                        break;

                case 2 :
                        copie = MonoBehaviour.Instantiate(itemBulle, this.transform.position, this.transform.rotation) as GameObject;
                        DonneBulle bulle = copie.GetComponent(typeof(DonneBulle)) as DonneBulle;
                        bulle.init = false;
                        break;
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            init = true;
        }
    }
}
