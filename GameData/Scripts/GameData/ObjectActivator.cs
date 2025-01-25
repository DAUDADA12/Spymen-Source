using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    private GetInteraction interaction;
    public GameObject ObjectToActivate;

    void Start()
    {
        interaction = GetComponent<GetInteraction>();
    }

    void Update()
    {
        if(interaction.isOn)
        {
            ObjectToActivate.SetActive(true);
            Destroy(GetComponent<ObjectActivator>());
        }
    }
}
