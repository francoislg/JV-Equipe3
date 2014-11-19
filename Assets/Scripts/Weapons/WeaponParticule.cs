using UnityEngine;
using System.Collections;

public class WeaponParticule : Weapon
{
    private GameObject imageProjectile;
    private GameObject projectile;
    private Munition particule;

    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        base.InitWeapon(weaponHolder, bulletPool);
        this.CooldownDuration = 0f;
        this.speed = 10;
        this.damage = 10;
        this.duration = 10;
        this.color = Color.red;
        this.joueur = true;
    }

    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool, int poolSize, float CoolDown, int speed, int dmg, int duration, Color color, bool joueur)
    {
        base.InitWeapon(weaponHolder, bulletPool, poolSize, CoolDown, speed, dmg, duration, color, joueur);
    }

    protected void Start()
    {
        icon = Resources.Load("Sprites/slingshotIcon") as Texture2D;
        imageProjectile = LoadBullet("Bulle");
        projectile = MonoBehaviour.Instantiate(imageProjectile, transform.position, transform.rotation) as GameObject;
        projectile.transform.Translate(0, 0, 0, Space.Self);
        projectile.transform.parent = this.transform;
        particule = projectile.GetComponent(typeof(Munition)) as Munition;
        particule.speed = this.speed;
        particule.baseDamage = this.damage;
        particule.duration = this.duration;
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
}
