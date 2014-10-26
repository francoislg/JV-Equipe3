using UnityEngine;
using System.Collections;

public class BalloonShooter : Weapon
{
    private GameObject projectile;
    private float speed = 6f;

    public BalloonShooter(GameObject weaponHolder)
        : base(weaponHolder)
    {
        CooldownDuration = 0.5f;
        projectile = LoadBullet("Balloon");
    }

    public override void ShootAt(Vector3 target)
    {
        GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, weaponHolder.transform.position, Quaternion.identity);
        newProjectile.transform.LookAt(target);
        Vector3 fwd = newProjectile.transform.forward;
        newProjectile.rigidbody.velocity = new Vector3(fwd.x * speed, (10 * fwd.y) + 7, fwd.z * speed);
    }
}
