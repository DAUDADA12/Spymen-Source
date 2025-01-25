using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLimiter : MonoBehaviour
{
    [HideInInspector] public CameraMovement CamCode;
    private GameObject Player;
    public Transform CameraLimitPoint1;
    public Transform CameraLimitPoint2;

    void Start()
    {
        CamCode = GetComponent<CameraMovement>();
        Player = CamCode.Player;
    }

    void Update()
    {
        if (!CamCode.Stop)
        {
            if (Player.transform.position.x > CameraLimitPoint1.position.x && Player.transform.position.x < CameraLimitPoint2.position.x)
            {
                CamCode.enabled = true;
            }
            else
            {
                CamCode.enabled = false;
            }
        }
        else
        {
            CamCode.enabled = false;
            return;
        }
    }
}
