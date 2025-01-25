using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Walking Player;
    public GameObject projectilePrefab; // The projectile to be fired
    public Transform firePoint;         // The point where the projectile is spawned
    public float fireForce = 10f;       // Force with which the projectile is shot
    public float fireRate = 50f;         // Rate of fire in shots per second
    public int MagSize = 30;
    public int AmmoInventory = 120;
    public float ReloadTime = 2f;
    public int CurrentAmmo;
    private float nextFireTime = 0f;
    public AudioSource audioSource;
    private ShootScript shootScript;
    [HideInInspector] public int ShowAmmo;
    private GameObject ReloadButton;
    [HideInInspector] public bool HasMaxAmmo;
    private AudioSource ReloadSound;

    void Start()
    {
        CurrentAmmo = MagSize;
        shootScript = GetComponent<ShootScript>();
        ReloadButton = Player.ReloadButton;
        ReloadSound = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        Player.ReloadButton.SetActive(true);
        Player.ShootButton.SetActive(true);
    }

    void OnDisable()
    {
        Player.ReloadButton.SetActive(false);
        Player.ShootButton.SetActive(false);
    }

    void FixedUpdate()
    {
        ShowAmmo = CurrentAmmo;
        if (Time.time >= nextFireTime && shootScript.ShootTarget)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }

        if(CurrentAmmo != MagSize)
        {
            ReloadButton.SetActive(true);
            HasMaxAmmo = false;
        }
        else
        {
            ReloadButton.SetActive(true);
            HasMaxAmmo = true;
        }
    }

    public void ReloadGun()
    {
        if(!HasMaxAmmo)
            StartCoroutine(Reload());
        else
            Debug.Log("Ammo is Full!");
    }

    void Shoot()
    {
        if(CurrentAmmo > 0)
        {
            audioSource.mute = false;
            // Instantiate the projectile at the fire point position and rotation
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            CurrentAmmo--;
            Player.UpdateAmmo();

            // Apply force to the projectile's Rigidbody2D component
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
                projectile.transform.rotation = Quaternion.Euler(0, 0f, 90f);
            }
        }
        else
            audioSource.mute = true;
    }

    public IEnumerator Reload()
    {
        ReloadSound.Play();
        Debug.Log("Reloading.....");

        yield return new WaitForSeconds(ReloadTime);

        if(AmmoInventory > MagSize)
        {
            AmmoInventory = AmmoInventory - (MagSize - CurrentAmmo);
            CurrentAmmo = MagSize;
        }
        else
        {
            CurrentAmmo += AmmoInventory;
        }
        Debug.Log("Done!");
    }
}

