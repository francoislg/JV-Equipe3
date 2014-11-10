using UnityEngine;
using System.Collections;

public class PlayerHasWeapon : MonoBehaviour
{
    Weapon[] weapons = new Weapon[2];
    float cooldownUntil;

    public void GiveWeapon(string weaponName)
    {
        int num = FindFreeWeapon();
        if (num >= 0)
        {
            GameObject.Destroy(weapons[num]);
            weapons[num] = gameObject.AddComponent(weaponName) as Weapon;
        }
    }

    int FindFreeWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    void Start()
    {
        GiveWeapon("Slingshot");
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
        if (weapons[0] != null && Input.GetMouseButton(0) && cooldownUntil <= 0)
        {
            weapons[0].ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = weapons[0].cooldownDuration;
        }
        else if (weapons[1] != null && Input.GetMouseButton(1) && cooldownUntil <= 0)
        {
            weapons[1].ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
            cooldownUntil = weapons[1].cooldownDuration;
        }
    }
}
