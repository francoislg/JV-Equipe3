using UnityEngine;
using System.Collections;

public class PlayerHasWeapon : MonoBehaviour
{
    private Weapon leftWeapon;
    private Weapon rightWeapon;
    private float cooldownUntil;

    void Start()
    {
        leftWeapon = new Slingshot(gameObject);
        rightWeapon = new BalloonShooter(gameObject);
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
            leftWeapon.ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = leftWeapon.CooldownDuration;
        }
        else if (Input.GetMouseButton(1) && cooldownUntil <= 0)
        {
            rightWeapon.ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = rightWeapon.CooldownDuration;
        }
    }
}
