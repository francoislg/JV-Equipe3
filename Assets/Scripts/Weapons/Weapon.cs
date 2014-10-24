using UnityEngine;
using System.Collections;

public abstract class Weapon
{
    public float CooldownDuration { get; protected set; }

    protected GameObject weaponHolder;

    public Weapon(GameObject weaponHolder)
    {
        this.weaponHolder = weaponHolder;
        CooldownDuration = 1.0f;
    }

    protected GameObject LoadBullet(string name)
    {
        return (GameObject)Resources.Load("Prefabs/Bullets/" + name, typeof(GameObject));
    }

    public abstract void ShootAt(Vector3 target);
}