using UnityEngine;
using System.Collections;

public class PlayerHasWeapon : MonoBehaviour
{
    Weapon leftWeapon;
    Weapon rightWeapon;
    float cooldownUntil;

    void Start()
    {
        leftWeapon = gameObject.AddComponent<Slingshot>();
        rightWeapon = null;
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

    void HandleFire(RaycastHit mouseRayHit)
    {
        if (leftWeapon != null && Input.GetMouseButton(0) && cooldownUntil <= 0)
        {
            leftWeapon.ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = leftWeapon.cooldownDuration;
        }
        else if (rightWeapon != null && Input.GetMouseButton(1) && cooldownUntil <= 0)
        {
            rightWeapon.ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = rightWeapon.cooldownDuration;
        }
    }
}
