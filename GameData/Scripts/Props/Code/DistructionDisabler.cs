using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistructionDisabler : MonoBehaviour
{
    public Behaviour[] CodesToDisable;

    void OnDestroy() 
    {
        for(int i = 0; i < CodesToDisable.Length; i ++)
        {
            CodesToDisable[i].enabled = false;
        }
    }
}
