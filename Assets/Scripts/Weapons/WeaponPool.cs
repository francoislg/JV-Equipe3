using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class WeaponPool : Weapon
{
    protected GameObject imageProjectile;
    protected GameObject projectile;
    protected Munition activeBullet;
    protected List<GameObject> bulletPoolReady;
    protected List<GameObject> bulletPoolActive;
    protected int poolSize;


    public override void InitWeapon(GameObject weaponHolder, Transform bulletPool, int poolSize, float CoolDown, int speed, int dmg, int duration, int collision, Color color, bool joueur)
    {
        base.InitWeapon(weaponHolder, bulletPool, poolSize, CoolDown, speed, dmg, duration, collision, color, joueur);
        this.bulletPool = bulletPool;
        this.poolSize = poolSize;
    }

    protected virtual void Start()
    {
        InitPool();
    }

    protected GameObject LoadBullet(string name)
    {
        return (GameObject)Resources.Load("Prefabs/Bullets/" + name, typeof(GameObject));
    }

    public void InitPool()
    {
        bulletPoolReady = new List<GameObject>();
        bulletPoolActive = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            projectile = MonoBehaviour.Instantiate(imageProjectile, bulletPool.position, bulletPool.rotation) as GameObject;
            projectile.transform.Translate(0, 0, 0, Space.Self);
            projectile.transform.parent = bulletPool;
            bulletPoolReady.Add(projectile);
        }
    }

    public void FixedUpdate()
    {
        for (int i = 0; i < bulletPoolActive.Count; i++)
        {
            projectile = (GameObject)bulletPoolActive[i];
            activeBullet = projectile.GetComponent(typeof(Munition)) as Munition;
            if (activeBullet.Actif)
            {
                if (activeBullet.Expirer)
                {
                    activeBullet.Actif = false;
                    activeBullet.transform.position = bulletPool.position;
                    bulletPoolActive.RemoveAt(i);
                    bulletPoolReady.Add(projectile);
                }
            }
        }
    }

    public override void ShootAt(Vector3 target)
    {
        if (bulletPoolReady.Count > 0)
        {
            projectile = (GameObject)bulletPoolReady[0];
            activeBullet = projectile.GetComponent(typeof(Munition)) as Munition;
            activeBullet.speed = this.speed;
            activeBullet.baseDamage = this.damage;
            activeBullet.duration = this.duration;
            activeBullet.NbCollision = this.nbCollision;
            activeBullet.color = this.color;
            activeBullet.joueur = this.joueur;
            activeBullet.Spawner = this.weaponHolder.transform;
        }
    }

    public void Fire(Vector3 target)
    {       
        activeBullet.Fire(target);
        bulletPoolReady.RemoveAt(0);
        bulletPoolActive.Add(projectile);
    }
}