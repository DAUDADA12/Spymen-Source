using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Walking : MonoBehaviour
{
    public string GroundName = "Ground";
    public GameObject ReloadButton;
    private bool hasRifle;
    public float WalkSpeed;
    public float JumpForce;
    public GameObject InteractButton;
    public Animator BlendAnimation;
    public GameObject DeathUI;
    public GameObject MoveUI;
    public GameObject ObjectiveText;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool isUsed;
    [HideInInspector] bool isGrounded;
    [HideInInspector] Rigidbody2D PlayerRB;
    [HideInInspector] public Animator PlayerAnimator;
    [HideInInspector] public bool Walking_Left;
    [HideInInspector] public bool Walking_Right;
    [HideInInspector] public bool Interactable;
    [HideInInspector] public GetInteraction InteractionCode;
    [HideInInspector] public Image BlendImage;
    [HideInInspector] public CameraMovement PlayerCam;
    [HideInInspector]public bool isWalking;
    [HideInInspector]public AudioSource WalkSound;
    public AudioSource DamageSound;
    public GameObject PrimaryWeapon;
    public GameObject SecondaryWeapon;
    [HideInInspector] public ShootScript PrimaryWeaponShootCode;
    public GameObject ShootButton;
    [SerializeField]private Gun CurrentGun;
    [HideInInspector] public ShootScript SecondaryWeaponShootCode;
    public GameObject AmmoTextContainer;
    [HideInInspector]public TMP_Text AmmoText;
    [HideInInspector] public bool hasPistol;
    public bool NeedsGun = true;

    private List<string> Keys = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        if(NeedsGun)
        {
            PrimaryWeaponShootCode = PrimaryWeapon.GetComponentInChildren<ShootScript>();
            SecondaryWeaponShootCode = SecondaryWeapon.GetComponentInChildren<ShootScript>();
            AmmoText = AmmoTextContainer.GetComponentInChildren<TMP_Text>();
        }
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        BlendImage = BlendAnimation.gameObject.GetComponent<Image>();
        WalkSound = GetComponent<AudioSource>();
        DamageSound.enabled = true;
        WalkSound.enabled = true;
        if(InstanceManager.Instance.Chances <= 0)
            isDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        Walking_Code();
        if (!isDead)
        {
            isUsedDectect();
            isGrounded_Check();
        }
    }

    public void Reload()
    {
        CurrentGun.ReloadGun();
    }

    public void Damage()
    {
        DamageSound.Play();
    }

    public void HasRifle()
    {
        SecondaryWeapon.SetActive(false);
        PlayerAnimator.SetBool("hasPistol", false);
        hasPistol = false;

        if(PlayerAnimator.GetBool("hasRifle") == true)
        {
            PlayerAnimator.SetBool("hasRifle", false);
            PrimaryWeapon.SetActive(false);
            CurrentGun = null;
            hasRifle = false;
            AmmoTextContainer.SetActive(false);
        }
        else
        {
            PlayerAnimator.SetBool("hasRifle", true);
            PrimaryWeapon.SetActive(true);
            CurrentGun = PrimaryWeapon.GetComponentInChildren<Gun>();
            if(CurrentGun != null)    
                hasRifle = true;
            AmmoTextContainer.SetActive(true);
        }
    }

    public void HasPistol()
    {
        PrimaryWeapon.SetActive(false);
        PlayerAnimator.SetBool("hasRifle", false);
        hasRifle = false;

        if(PlayerAnimator.GetBool("hasPistol") == true)
        {
            SecondaryWeapon.SetActive(false);
            CurrentGun = null;
            hasPistol = false;
            AmmoTextContainer.SetActive(false);
            PlayerAnimator.SetBool("hasPistol", false);
        }
        else
        {
            SecondaryWeapon.SetActive(true);
            CurrentGun = SecondaryWeapon.GetComponentInChildren<Gun>();
            AmmoTextContainer.SetActive(true);
            if(CurrentGun != null)
                hasPistol = true;
            PlayerAnimator.SetBool("hasPistol", true);
        }
    }

    void FixedUpdate()
    {
        if(CurrentGun != null)
        {
            UpdateAmmo();
            if (InstanceManager.Instance.GetHealthInfo() <= 0)
                isDead = true;

            if(PlayerAnimator.GetBool("hasRifle") == true)
            {
                ShootButton.SetActive(true);
                ReloadButton.SetActive(true);
            }
            else if(PlayerAnimator.GetBool("hasPistol") == true)
            {
                ShootButton.SetActive(true);
                ReloadButton.SetActive(true);
            }
            else
            {
                ShootButton.SetActive(false);
                ReloadButton.SetActive(false);
            }
        }

        if(CurrentGun != null)
        {
            if(isGrounded)
                CurrentGun.gameObject.SetActive(true);
            else
                CurrentGun.gameObject.SetActive(false);
        }

        
        if (!isDead)
            CheckInteraction();
            CheckMovement();
    }
    void Walking_Code()
    {
        if (isDead)
        {
            WalkSound.Stop();
            Walk(0f);
            DeathUI.SetActive(true);
            InstanceManager.Instance.Chances -= 1;
            InstanceManager.Instance.HP = InstanceManager.Instance.MaxHealth;
            if (DeathUI.activeSelf)
            {
                Destroy(MoveUI);
                Destroy(ObjectiveText);
                InstanceManager.Instance.RemoveKeyList(Keys);
                PlayerCam.Stop = true;
                if (DeathUI.activeSelf)
                {
                    Destroy(gameObject);
                    return;
                }
            }
        }

        if (Walking_Left)
            Walk(-1);
        else if (Walking_Right)
            Walk(1);
        else if (Input.GetButton("Horizontal") && !Walking_Left && !Walking_Right)
            Walk(Input.GetAxis("Horizontal"));
        else
            Walk(0);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (PlayerRB.linearVelocityX != 0)
            isWalking = true;
        else
            isWalking = false;
    }

    void CheckMovement()
    {
        if(isWalking)
            WalkSound.mute = false;
        else
            WalkSound.mute = true;
    }

    public void AddKey(string KeyName)
    {
        Keys.Add(KeyName);
    }

    void isUsedDectect()
    {
        if (isUsed)
            BlendAnimation.SetBool("isUsed", true);
        else
            BlendAnimation.SetBool("isUsed", false);
    }
    void CheckInteraction()
    {
        if (Interactable)
            InteractButton.SetActive(true);
        else if (gameObject.IsDestroyed())
            return;
        else
            InteractButton.SetActive(false);
    }
    public void Walk_Left(bool Move)
    {
        Walking_Left = Move;
    }
    public void Walk_Right(bool Move)
    {
        Walking_Right = Move;
    }
    public void Walk(float Effector)
    {
        float Speed = WalkSpeed * Effector;


        if (isGrounded)
        {
            if (Speed != 0f)
            {
                PlayerAnimator.SetBool("Walking", true);
            }
            else
            {
                PlayerAnimator.SetBool("Walking", false);
            }

            Vector2 velocity = new Vector2(Speed, PlayerRB.linearVelocity.y);

            PlayerRB.linearVelocity = velocity;

            if (Speed < 0f)
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0f);
            }
            if (Speed > 0f)
            {
                transform.rotation = Quaternion.Euler(0, 0f, 0f);
            }
        }
    }
    public void Jump()
    {
        if (isGrounded)
        {
            PlayerRB.AddForce(Vector2.up * PlayerRB.mass * JumpForce, ForceMode2D.Impulse);
        }
    }
    void isGrounded_Check()
    {
        if (isGrounded)
        {
            PlayerAnimator.SetBool("isGrounded", true);
        }
        else
        {
            PlayerAnimator.SetBool("isGrounded", false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == GroundName)
            isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == GroundName)
            isGrounded = false;
    }
    public void Interact()
    {
        if (!InteractionCode.isSwitch)
            InteractionCode.isOn = true;
        else
        {
            InteractionCode.isOn = !InteractionCode.isOn;
        }
    }

    public void UpdateAmmo()
    {
        if(hasRifle)
        {
            AmmoText.text = $"{CurrentGun.CurrentAmmo} | {CurrentGun.AmmoInventory}";

            if(CurrentGun.CurrentAmmo == 0)
                AmmoText.color = Color.red;
            else
                AmmoText.color = Color.white;
        }
        if(hasPistol)
        {
            AmmoText.text = $"{CurrentGun.CurrentAmmo} | {CurrentGun.AmmoInventory}";

            if(CurrentGun.CurrentAmmo == 0)
                AmmoText.color = Color.red;
            else
                AmmoText.color = Color.white;
        }
    }
}