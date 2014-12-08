using UnityEngine;
using System.Collections;

public class DonneBonusSpeed : MessageDrawer {

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHasWeapon joueur = other.gameObject.GetComponent("PlayerHasWeapon") as PlayerHasWeapon;
            joueur.giveBonusSpeed();
            ShowMessage("VITESSE+!");
            if (renderer)
            {
                renderer.enabled = false;
            }
            else
            {
                Renderer childRend = GetComponentInChildren<Renderer>() as Renderer;
                if (childRend)
                {
                    childRend.enabled = false;
                }
            }
        }
    }
}
