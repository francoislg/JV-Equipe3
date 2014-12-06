using UnityEngine;
using System.Collections;

public class WeaponParticule : Weapon
{
    private GameObject imageProjectile;
    private GameObject projectile;
    private Munition particule;

    private int emissionRate;
    private int emissionAngle;

    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        base.InitWeapon(weaponHolder, bulletPool);
        this.CooldownDuration = 0f;
        this.speed = 5;
        this.damage = 10;
        this.duration = 10;
        this.emissionRate = 2;
        this.emissionAngle = 5;
        this.color = Color.red;
        this.joueur = true;
        this.nom = "Bulle";
    }

    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool, int poolSize, float CoolDown, int speed, int dmg, int duration, int collision, Color color, bool joueur)
    {
        base.InitWeapon(weaponHolder, bulletPool, poolSize, CoolDown, speed, dmg, duration, collision, color, joueur);
    }

    protected void Start()
    {
		icon = Resources.Load("Sprites/bubble") as Texture2D;

        imageProjectile = LoadBullet("Bulle");
        projectile = MonoBehaviour.Instantiate(imageProjectile, transform.position, transform.rotation) as GameObject;
        projectile.transform.Translate(0, 0, 0, Space.Self);
        projectile.transform.parent = this.transform;
        particule = projectile.GetComponent(typeof(Munition)) as Munition;
        particule.speed = this.speed;
        particule.baseDamage = this.damage;
        particule.duration = this.duration;
        particule.emissionRate = this.emissionRate;
        particule.emissionAngle = this.emissionAngle;
        particule.color = this.color;
        particule.joueur = this.joueur;
        particule.Spawner = this.weaponHolder.transform;
    }

    protected GameObject LoadBullet(string name)
    {
        return (GameObject)Resources.Load("Prefabs/Bullets/" + name, typeof(GameObject));
    }

    public override void ShootAt(Vector3 target)
    {
        particule.Fire(target);
    }

    public override void GiveBonus()
    {
        particule.emissionRate = 8;
        particule.emissionAngle = 20;
    }

    public override void GiveSpeed()
    {
         particule.speed = 10;
    }

    public override void GiveDamage()
    {
         particule.baseDamage = 20;
    }
}
