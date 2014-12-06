using UnityEngine;
using System.Collections;

public class Slingshot : WeaponPool
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
        this.nbCollision = 0;
        this.nom = "Slingshot";
    }

    protected override void Start()
    {
        imageProjectile = LoadBullet("bullet");
        icon = Resources.Load("Sprites/slingshotIcon") as Texture2D;
        base.Start();
    }

    public override void GiveBonus()
    {
        nbCollision = 3;
    }

    public override void GiveSpeed()
    {
        speed = 20;
    }

    public override void GiveDamage()
    {
        damage = 20;
    }

    public override void ShootAt(Vector3 target)
    {
        base.ShootAt(target);
        base.Fire(target);
    }

}
