using UnityEngine;
using System.Collections;

public class Slingshot : Weapon
{
    GameObject projectile;
    float speed = 20.0f;

    void Start()
    {
        projectile = Resources.Load("Prefabs/Bullets/bullet") as GameObject;
        icon = Resources.Load("Sprites/slingshotIcon") as Texture2D;
    }

    public override void ShootAt(Vector3 target)
    {
        GameObject newProjectile = (GameObject)MonoBehaviour.Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.transform.LookAt(target);
        newProjectile.renderer.material.color = Color.red;
        newProjectile.rigidbody.velocity = (newProjectile.transform.forward * speed);
    }
}
