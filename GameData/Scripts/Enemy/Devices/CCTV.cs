using UnityEngine;

public class CCTV : MonoBehaviour
{
    public cctvTrigger ColliderForRange;
    [SerializeField]public GuardWalk[] Guards;
    [HideInInspector] public bool SawPlayer;
    private CCTV Code;
    private CCTVAlrmSender AlarmSender;
    private int GuardCount;
    private int GuardsSaw;

    void Start()
    {
        Code = GetComponent<CCTV>();
        AlarmSender = GetComponent<CCTVAlrmSender>();
        AlarmSender.Code = GetComponent<CCTV>();
    }

    void FixedUpdate() 
    {
        GuardCount = 0;
        GuardsSaw = 0;

        GuardsSaw = CountGuard();

        if(SawPlayer)
            AlarmSender.enabled = true;

        if(GuardsSaw == 0 && !SawPlayer)
            AlarmSender.enabled = false;
    }

    public int CountGuard()
    {
        foreach(var Guards in Guards)
        {
            if(Guards.CCTVAlarm)
            {
                GuardCount++;
            }
        }

        return GuardCount;
    }
}
