using UnityEngine;
using System.Collections;

public class Slingshot : Weapon
{
    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        base.InitWeapon(weaponHolder, bulletPool);
        this.poolSize = 20;
        this.CooldownDuration = 0.5f;
        this.speed = 10;
        this.damage = 10;
        this.duration = 10;
        this.color = Color.red;
        this.joueur = true;
    }

    protected override void Start()
    {
        imageProjectile = LoadBullet("bullet");
        icon = Resources.Load("Sprites/slingshotIcon") as Texture2D;
        base.Start();
    }

}
