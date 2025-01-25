using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    [HideInInspector] public bool isHidden = false;
    public Behaviour[] ThingsToDisableOrEnable;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D RB;
    private Walking walking;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        walking = GetComponent<Walking>();
    }

    void FixedUpdate()
    {
        if (isHidden)
        {
            for (int i = 0; i < ThingsToDisableOrEnable.Length; i++)
            {
                ThingsToDisableOrEnable[i].enabled = false;
            }
            RB.isKinematic = true;
            RB.simulated = false;
            spriteRenderer.enabled = false;
            walking.Walking_Left = false;
            walking.Walking_Right = false;
        }
        else
        {
            for (int i = 0; i < ThingsToDisableOrEnable.Length; i++)
            {
                ThingsToDisableOrEnable[i].enabled = true;
            }
            RB.isKinematic = false;
            spriteRenderer.enabled = true;
            RB.simulated = true;
        }
    }
}
