using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cctvTrigger : MonoBehaviour
{
    [HideInInspector] public GameObject Player;
    private Walking Code;
    public CCTV CCTVcode;


    void OnTriggerEnter2D(Collider2D other)
    {
        CCTVcode.enabled = true;
        Code = other.GetComponent<Walking>();
        if(other.tag == "Player" && Code != null)
        {
            Player = other.gameObject;
            CCTVcode.SawPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && Code != null)
        {
            CCTVcode.SawPlayer = false;
            Code = null;
        }
    }
}
