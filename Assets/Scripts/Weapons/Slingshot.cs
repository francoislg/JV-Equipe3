using UnityEngine;
using System.Collections;

public class Slingshot : Weapon
{
    GameObject  projectile;
    float       speed = 20.0f;

    public Slingshot(GameObject weaponHolder)
        : base(weaponHolder)
    {
        projectile = LoadBullet("bullet");
    }

    public override void ShootAt(Vector3 target)
    {
        GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, weaponHolder.transform.position, Quaternion.identity);
        newProjectile.transform.LookAt(target);
        newProjectile.renderer.material.color = Color.red;
        newProjectile.rigidbody.velocity = (newProjectile.transform.forward * speed);
    }
}
