using UnityEngine;
using System.Collections;

public abstract class Weapon
{
    protected GameObject weaponHolder;
    protected float cooldown = 1.0f;

    public Weapon(GameObject weaponHolder)
    {
        this.weaponHolder = weaponHolder;
    }

    public float getCooldown()
    {
        return cooldown;
    }

    protected GameObject LoadBullet(string name)
    {
        return (GameObject)Resources.Load("Prefabs/Bullets/" + name, typeof(GameObject));
    }

    public abstract void shootAt(Vector3 target);
    public abstract void remove();
}