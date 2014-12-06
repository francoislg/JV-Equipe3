using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    
    protected GameObject weaponHolder;
    public Texture2D icon { get; protected set; }
    protected Transform bulletPool;

    public float CooldownDuration { get; set; }
    public int speed { get; set; }
    public int damage { get; set; }
    public int duration { get; set; }
    public Color color { get; set; }
    public bool joueur { get; set; }
    public int nbCollision { get; set; }

    public string nom { get; set; }


    public virtual void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        this.bulletPool = bulletPool;
        this.weaponHolder = weaponHolder;
    }

    public virtual void InitWeapon(GameObject weaponHolder, Transform bulletPool, int poolSize, float CoolDown, int speed, int dmg, int duration, int collision, Color color, bool joueur)
    {
        this.weaponHolder = weaponHolder;
        this.CooldownDuration = CoolDown;
        this.speed = speed;
        this.damage = dmg;
        this.duration = duration;
        this.nbCollision = collision;
        this.color = color;
        this.joueur = joueur;
    }

    public virtual void GiveBonus()
    {
    }

    public virtual void GiveSpeed()
    {
    }

    public virtual void GiveDamage()
    {
    }

    public virtual void ShootAt(Vector3 target)
    {
    }
}