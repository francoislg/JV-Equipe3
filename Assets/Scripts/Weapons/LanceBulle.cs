using UnityEngine;
using System.Collections;

public class LanceBulle : Weapon 
{
    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
    }

    protected void Start()
    {
        icon = Resources.Load("Sprites/slingshotIcon") as Texture2D;
    }

}
