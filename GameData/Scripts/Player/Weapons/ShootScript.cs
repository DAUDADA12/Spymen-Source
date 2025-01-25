using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public bool ShootTarget;
    public GameObject IdleWeaponState;
    public GameObject Shoot;
    private Walking walkingcode;
    private Animator PlayerAnimator;
    private Gun GunCode;

    void Start()
    {
        walkingcode = GetComponentInParent<Walking>();
        PlayerAnimator = GetComponentInParent<Animator>();
        GunCode = GetComponentInChildren<Gun>();
    }

    void FixedUpdate() 
    {
        if(ShootTarget)
        {
            IdleWeaponState.SetActive(false);
            Shoot.SetActive(true);
            PlayerAnimator.SetBool("Shoot", true);
            walkingcode.enabled = false;
        }
        
        if(!ShootTarget)
        {
            IdleWeaponState.SetActive(true);
            walkingcode.enabled = true;
            Shoot.SetActive(false);
            PlayerAnimator.SetBool("Shoot", false);
        }
    }
}
