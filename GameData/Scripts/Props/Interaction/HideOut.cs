using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOut : MonoBehaviour
{
    public GetInteraction getInteraction;

    void Start()
    {
        getInteraction = GetComponent<GetInteraction>();
        getInteraction.isSwitch = true;
        getInteraction.isHideOut = true;
    }

    void FixedUpdate()
    {
        if (getInteraction.isOn)
            getInteraction.walking.gameObject.GetComponent<HideScript>().isHidden = true;
        else
        {
            if (getInteraction.walking != null)
            {
                getInteraction.walking.gameObject.GetComponent<HideScript>().isHidden = false;
            }
        }
    }
}
