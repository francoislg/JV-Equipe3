using UnityEngine;
using System.Collections;

public class BalloonShooter : WeaponPool
{

    public int contactZone;
    public float explosionSpeed;
    public float explosionLifeTime;

    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        base.InitWeapon(weaponHolder, bulletPool);
        this.poolSize = 20;
        this.CooldownDuration = 0.5f;
        this.speed = 5;
        this.damage = 10;
        this.duration = 10;
        this.color = Color.blue;
        this.joueur = true;
        this.contactZone = 3;
        this.explosionLifeTime = 0.6f;
        this.explosionSpeed = 3;
        this.nom = "Balloon";
    }

    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool, int poolSize, float CoolDown, int speed, int dmg, int duration, int collision, Color color, bool joueur)
    {
        base.InitWeapon(weaponHolder, bulletPool, poolSize, CoolDown, speed, dmg, duration, collision, color, joueur);
        this.contactZone = 3;
        this.explosionLifeTime = 0.6f;
        this.explosionSpeed = 3;
    }

    protected override void Start()
    {
        imageProjectile = LoadBullet("balloon");
        icon = Resources.Load("Sprites/balloon") as Texture2D;
        base.Start();
    }

    public override void GiveBonus()
    {
        this.contactZone = 8;
        this.explosionLifeTime = 3f;
        this.explosionSpeed = 20;
    }

    public override void GiveSpeed()
    {
        speed = 10;
    }

    public override void GiveDamage()
    {
        damage = 20;
    }

    public override void ShootAt(Vector3 target)
    {
        base.ShootAt(target);
        activeBullet.contactZone = this.contactZone;
        activeBullet.explosionLifeTime = this.explosionLifeTime;
        activeBullet.explosionSpeed = this.explosionSpeed;
        base.Fire(target);
    }
}
