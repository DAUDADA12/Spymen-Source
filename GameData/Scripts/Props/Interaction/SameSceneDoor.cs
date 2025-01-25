using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SameSceneDoor : MonoBehaviour
{
    private GetInteraction interaction;
    public GameObject OpenDoorSprite;
    public GameObject CloseDoorSprite;

    void Start()
    {
        interaction = GetComponent<GetInteraction>();
        interaction.isSwitch = true;
    }

    void FixedUpdate()
    {
        if (interaction.isOn)
        {
            OpenDoorSprite.SetActive(true);
            CloseDoorSprite.SetActive(false);
        }
        else
        {
            OpenDoorSprite.SetActive(false);
            CloseDoorSprite.SetActive(true);
        }
    }
}
