
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChancesPrinter : MonoBehaviour
{
    public TMP_Text ChancesText;

    // Start is called before the first frame update
    void Start()
    {
        ChancesText.text = "Chances Left: " + InstanceManager.Instance.Chances;

        if(InstanceManager.Instance.Chances <= 0)
        {
            ChancesText.text = "Chances Left: 0";
            ChancesText.color = Color.red;
        }
    }
}
