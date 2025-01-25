using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyContainer : MonoBehaviour
{
    public string KeyName;
    private GetInteraction Code;

    // Start is called before the first frame update
    void Start()
    {
        Code = GetComponent<GetInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Code.isOn)
        {
            InstanceManager.Instance.AddKey(KeyName);
            if (Code.walking != null)
                Code.walking.ObjectiveText.SetActive(true);
            else
                return;
        }
    }
}
