using UnityEngine;
using System.Collections;

public abstract class Weapon
{
    public float Cooldown { get ; protected set ;}

    protected GameObject weaponHolder;

    public Weapon(GameObject weaponHolder)
    {
        this.weaponHolder = weaponHolder;
        Cooldown = 1.0f;
    }

    protected GameObject LoadBullet(string name)
    {
        return (GameObject)Resources.Load("Prefabs/Bullets/" + name, typeof(GameObject));
    }

    public abstract void shootAt(Vector3 target);
}