using UnityEngine;
using System.Collections;

public class HasWeapon : MonoBehaviour
{
    private Weapon weapon;
    private Weapon rightWeapon;
    private float cooldownUntil;

    void Start()
    {
        weapon = new Slingshot(this.gameObject);
        rightWeapon = new BalloonShooter(this.gameObject);
    }

    void Update()
    {
        cooldownUntil -= Time.deltaTime;

        RaycastHit mouseRayHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseRayHit))
        {
            HandleFire(mouseRayHit);
        }
    }

    private void HandleFire(RaycastHit mouseRayHit)
    {
        if (Input.GetMouseButton(0) && cooldownUntil <= 0)
        {
            weapon.ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = weapon.CooldownDuration;
        }
        else if (Input.GetMouseButton(1) && cooldownUntil <= 0)
        {
            rightWeapon.ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = rightWeapon.CooldownDuration;
        }
    }
}
