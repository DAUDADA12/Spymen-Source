using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVAlrmSender : MonoBehaviour
{
    [HideInInspector] public CCTV Code;
    private LookPlayer[] lookPlayers;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Code.SawPlayer)
        {
            for(int i=0; i<Code.Guards.Length;i++)
            {
                if(Code.Guards[i] != null)
                {
                    Code.Guards[i].Player = Code.ColliderForRange.Player.transform;
                    Code.Guards[i].CCTVAlarm = true;
                }
            }
        }
        else
        {
            for(int i=0; i<Code.Guards.Length;i++)
            {
                if(Code.Guards[i] != null)
                {
                    Code.Guards[i].CCTVAlarm = false;
                    Code.Guards[i].Player = null;
                }
            }
        }
    }
}
