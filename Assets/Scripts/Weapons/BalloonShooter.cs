using UnityEngine;
using System.Collections;

public class BalloonShooter : Weapon
{
    GameObject projectile;
    float speed = 6f;

    void Start()
    {
        cooldownDuration = 0.5f;
        projectile = Resources.Load("Prefabs/Bullets/Balloon") as GameObject;
    }

    public override void ShootAt(Vector3 target)
    {
        GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.transform.LookAt(target);
        Vector3 fwd = newProjectile.transform.forward;
        newProjectile.rigidbody.velocity = new Vector3(fwd.x * speed, (10 * fwd.y) + 7, fwd.z * speed);
    }
}
