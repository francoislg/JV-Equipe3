using UnityEngine;
using System.Collections;

public class PlayerHasWeapon : MonoBehaviour
{
    const int iconSize = 70;
    const int screenMargin = 20;

    Weapon[] weapons = new Weapon[3];
    Rect[] weaponRects = new Rect[1];

    public int currentWeapon;
    private Transform bulletPool;
    float cooldownUntil;

    void Start()
    {
        ConfigureHud();

        GameObject obj = new GameObject("MunitionPool");
        obj.transform.position = new Vector3(0, -10, 0);
        bulletPool = obj.transform;

        weapons[0] = gameObject.AddComponent("Slingshot") as Weapon;
        weapons[1] = gameObject.AddComponent("BalloonShooter") as Weapon;
        weapons[2] = gameObject.AddComponent("WeaponParticule") as Weapon;

        weapons[0].InitWeapon(gameObject, bulletPool);
        weapons[1].InitWeapon(gameObject, bulletPool);
        weapons[2].InitWeapon(gameObject, bulletPool);

        currentWeapon = 0;
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
       // for (int i = 0; i < weapons.Length; i++)
        //{
           // if (weapons[i] != null && weapons[i].icon != null)
          //  {
                GUI.Box(weaponRects[0], weapons[currentWeapon].icon);
          //  }
        //}
    }

    void ConfigureHud()
    {
       // for (int i = 0; i < weapons.Length; i++)
       // {
            weaponRects[0] = new Rect(
                screenMargin + 0 * (iconSize + screenMargin),
                Screen.height - (iconSize + screenMargin),
                iconSize,
                iconSize);
        //}
    }

    public void GiveWeapon(int weaponNumber)
    {

        currentWeapon = weaponNumber;
        //int num = FindFreeWeapon();
        //if (num >= 0)
        //{
            //int num = 0;
            //GameObject.Destroy(weapons[num]);
            //weapons[num] = gameObject.AddComponent(weaponName) as Weapon;
            //weapons[num].InitWeapon(gameObject, bulletPool);
        //}
    }

    //int FindFreeWeapon()
    //{
    //    for (int i = 0; i < weapons.Length; i++)
    //    {
    //        if (weapons[i] == null)
    //        {
    //            return i;
    //        }
    //    }
    //    return -1;
    //}

    void HandlePlayerInput(RaycastHit mouseRayHit)
    {
        if (weapons[currentWeapon] != null && Input.GetMouseButton(0) && cooldownUntil <= 0)
        {
            FireWeapon(currentWeapon, mouseRayHit);
        }
        //else if (weapons[1] != null && Input.GetMouseButton(1) && cooldownUntil <= 0)
        //{
        //    FireWeapon(1, mouseRayHit);
        //}
    }

    void FireWeapon(int id, RaycastHit mouseRayHit)
    {
        weapons[id].ShootAt(new Vector3(mouseRayHit.point.x, transform.position.y, mouseRayHit.point.z));
        cooldownUntil = weapons[id].CooldownDuration;
    }

    public string getWeaponName()
    {
        return weapons[currentWeapon].nom;
    }
}
