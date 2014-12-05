using UnityEngine;
using System.Collections;

public class BalloonShooter : WeaponPool
{
    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        base.InitWeapon(weaponHolder, bulletPool);
        this.poolSize = 20;
        this.CooldownDuration = 0.5f;
        this.speed = 5;
        this.damage = 30;
        this.duration = 10;
        this.color = Color.blue;
        this.joueur = true;
        this.nom = "Balloon";
    }

    protected override void Start()
    {
        imageProjectile = LoadBullet("balloon");
        icon = Resources.Load("Sprites/balloon") as Texture2D;
        base.Start();
    }
}
