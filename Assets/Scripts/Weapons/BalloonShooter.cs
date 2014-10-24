using UnityEngine;
using System.Collections;

public class BalloonShooter : Weapon
{
    private GameObject projectile;
    private float speed = 3f;

    public BalloonShooter(GameObject weaponHolder)
        : base(weaponHolder)
    {
        CooldownDuration = 0.5f;
        projectile = LoadBullet("Balloon");
    }

    public override void ShootAt(Vector3 target)
    {
        GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, weaponHolder.transform.position, Quaternion.identity);
        newProjectile.renderer.material.color = Color.blue;
        newProjectile.rigidbody.useGravity = true;
        newProjectile.transform.LookAt(target);
        Vector3 fwd = newProjectile.transform.forward;
        newProjectile.rigidbody.velocity = new Vector3(fwd.x * speed, (10 * fwd.y) + 15, fwd.z * speed);
    }
}
