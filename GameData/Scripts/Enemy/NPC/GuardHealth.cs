using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardHealth : MonoBehaviour
{
    public int Health = 100;
    public Slider HealthBar;
    [SerializeField] private AudioSource HurtSound;

    void Start()
    {
        HealthBar.maxValue = Health;
        HealthBar.value = Health;
    }

    void Update()
    {
        if(Health <= 0)
            Destroy(gameObject);
    }

    public void Hurt()
    {
        HurtSound.Play();
    }

    void FixedUpdate()
    {
        HealthBar.value = Health;
    }
}
