using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    public float CooldownDuration { get; protected set; }
    protected GameObject weaponHolder;
    public Texture2D icon { get; protected set; }
    protected Transform bulletPool;
    protected int speed;
    protected int damage;
    protected int duration;
    protected Color color;
    protected bool joueur;


    public virtual void InitWeapon(GameObject weaponHolder, Transform bulletPool)
    {
        this.bulletPool = bulletPool;
        this.weaponHolder = weaponHolder;
    }

    public virtual void InitWeapon(GameObject weaponHolder, Transform bulletPool, int poolSize, float CoolDown, int speed, int dmg, int duration, Color color, bool joueur)
    {
        this.weaponHolder = weaponHolder;
        this.CooldownDuration = CoolDown;
        this.speed = speed;
        this.damage = dmg;
        this.duration = duration;
        this.color = color;
        this.joueur = joueur;
    }

    public virtual void ShootAt(Vector3 target)
    {
    }
}