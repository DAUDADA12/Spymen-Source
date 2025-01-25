using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SimpleNextCheckpointEnabler : MonoBehaviour
{
    public GameObject NextWaypoint;
    public TargetSetter targetcode;
    private GetInteraction interaction;

    void Start()
    {
        interaction = transform.parent.gameObject.GetComponent<GetInteraction>();
    }

    void FixedUpdate()
    {
        if(interaction.isOn)
        {
            NextWaypoint.SetActive(true);
            targetcode.Target = NextWaypoint.gameObject.GetComponent<SpriteRenderer>();

            if(NextWaypoint.activeSelf)
                Destroy(gameObject);
        }
        else
            targetcode.Target = GetComponent<SpriteRenderer>();
    }
}
