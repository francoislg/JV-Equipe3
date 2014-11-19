using UnityEngine;
using System.Collections;

public class PlayerHasWeapon : MonoBehaviour
{
    const int iconSize = 70;
    const int screenMargin = 20;

    Weapon[] weapons = new Weapon[2];
    Rect[] weaponRects = new Rect[2];

    private Transform bulletPool;
    float cooldownUntil;

    void Start()
    {
        ConfigureHud();

        GameObject obj = new GameObject("MunitionPool");
        obj.transform.position = new Vector3(0, -10, 0);
        bulletPool = obj.transform;
        GiveWeapon("WeaponParticule");
    }

    void Update()
    {
        cooldownUntil -= Time.deltaTime;

        RaycastHit mouseRayHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mouseRayHit))
        {
            HandlePlayerInput(mouseRayHit);
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] != null && weapons[i].icon != null)
            {
                GUI.Box(weaponRects[i], weapons[i].icon);
            }
        }
    }

    void ConfigureHud()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weaponRects[i] = new Rect(
                screenMargin + i * (iconSize + screenMargin),
                Screen.height - (iconSize + screenMargin),
                iconSize,
                iconSize);
        }
    }

    public void GiveWeapon(string weaponName)
    {
        int num = FindFreeWeapon();
        if (num >= 0)
        {
            GameObject.Destroy(weapons[num]);
            weapons[num] = gameObject.AddComponent(weaponName) as Weapon;
            weapons[num].InitWeapon(gameObject, bulletPool);
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

    void HandlePlayerInput(RaycastHit mouseRayHit)
    {
        if (weapons[0] != null && Input.GetMouseButton(0) && cooldownUntil <= 0)
        {
            FireWeapon(0, mouseRayHit);
        }
        else if (weapons[1] != null && Input.GetMouseButton(1) && cooldownUntil <= 0)
        {
            FireWeapon(1, mouseRayHit);
        }
    }

    void FireWeapon(int id, RaycastHit mouseRayHit)
    {
        weapons[id].ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
        cooldownUntil = weapons[id].CooldownDuration;
    }
}
