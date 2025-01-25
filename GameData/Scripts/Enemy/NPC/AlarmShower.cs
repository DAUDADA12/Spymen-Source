using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmShower : MonoBehaviour
{
    private void OnEnable() {
        GetComponent<AudioSource>().Play();
    }
}
