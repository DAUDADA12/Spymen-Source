using UnityEngine;

public class UseGun : MonoBehaviour
{
    public Walking Player;
    private GameObject PrimaryWeaponList;
    private ShootScript PrimaryWeapon;
    private GameObject SecondaryWeaponList;
    private ShootScript SecondaryWeapon;
    public bool ShootGun;

    void Start()
    {
        PrimaryWeapon = Player.PrimaryWeaponShootCode;
        PrimaryWeaponList = Player.PrimaryWeapon;
        SecondaryWeaponList = Player.SecondaryWeapon;
        SecondaryWeapon = Player.SecondaryWeaponShootCode;
    }

    public void Shoot(bool check)
    {
        ShootGun = check;
    }

    void FixedUpdate()
    {
        if(ShootGun && Player.NeedsGun)
        {
            if(PrimaryWeaponList.activeInHierarchy)
                PrimaryWeapon.ShootTarget = true;
            else if(SecondaryWeaponList.activeInHierarchy)
                SecondaryWeapon.ShootTarget = true;
            else
                Debug.LogError("Please Equip a Gun First");
        }
        else
        {
            if(Player.NeedsGun)
            {
                if(PrimaryWeaponList.activeInHierarchy)
                    PrimaryWeapon.ShootTarget = false;
                else if(SecondaryWeaponList.activeInHierarchy)
                    SecondaryWeapon.ShootTarget = false;
            }
        }
    }
}
