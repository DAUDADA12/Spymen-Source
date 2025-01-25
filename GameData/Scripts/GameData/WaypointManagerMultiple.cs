using UnityEngine;
using UnityEngine.UI;

public class WaypointManagerMultiple : MonoBehaviour
{
    public SpriteRenderer CurrentWaypoint;
    public SpriteRenderer NextWaypoint;
    private TargetSetter waypointCode;
    public Toggle ObjectiveCheckbox;
    public bool NeedsKey;
    public bool SameSceneKey;
    public string KeyName;
    private bool hasKey;

    void Start()
    {
        waypointCode = GetComponent<TargetSetter>();

        if(NeedsKey)
        {
            hasKey = InstanceManager.Instance.GetKey(KeyName);

            if(hasKey)
            {
                waypointCode.Target = NextWaypoint;
                Destroy(CurrentWaypoint.gameObject);
                ObjectiveCheckbox.isOn = true;
            }
            else
            {
                waypointCode.Target = CurrentWaypoint;
                Destroy(NextWaypoint.gameObject);
                ObjectiveCheckbox.isOn = false;
            }
        }

        if(SameSceneKey)
        {
            hasKey = InstanceManager.Instance.GetKey(KeyName);

            if(hasKey)
            {
                waypointCode.Target = NextWaypoint;
                Destroy(CurrentWaypoint.gameObject);
            }
            else
            {
                waypointCode.Target = CurrentWaypoint;
                NextWaypoint.gameObject.SetActive(false);
            }
        }
    }

    void FixedUpdate() 
    {
        if(SameSceneKey)
        {
            hasKey = InstanceManager.Instance.GetKey(KeyName);

            if(hasKey)
            {
                waypointCode.Target = NextWaypoint;
                NextWaypoint.gameObject.SetActive(true);
                Destroy(CurrentWaypoint.gameObject);
            }
            else
            {
                waypointCode.Target = CurrentWaypoint;
                NextWaypoint.gameObject.SetActive(false);
            }
        }
    }
}
