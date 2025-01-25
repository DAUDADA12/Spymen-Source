using UnityEngine;

public class GetInteraction : MonoBehaviour
{
    [HideInInspector] public Walking walking;
    public bool isOn;
    [HideInInspector] public bool isDoor;
    [HideInInspector] public bool isOneofMoreKey;
    public bool isSwitch;
    private Collider2D Trigger;
    public HideScript hideScript;
    [HideInInspector] public bool isHideOut = false;

    void Start()
    {
        Trigger = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isOn && isOneofMoreKey)
            Trigger.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            walking = player.GetComponent<Walking>();
            hideScript = player.GetComponent<HideScript>();
            if (walking != null)
            {
                walking.Interactable = true;
                walking.InteractionCode = GetComponent<GetInteraction>();
            }
        }

        if (player.tag == "NPC" && isSwitch && !isHideOut)
            isOn = true;
    }

    void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            walking = player.GetComponent<Walking>();
            hideScript = player.GetComponent<HideScript>();
            if (walking != null)
            {
                walking.Interactable = true;
                walking.InteractionCode = GetComponent<GetInteraction>();
            }
        }

        if (player.tag == "NPC" && isSwitch && !isHideOut)
            isOn = true;
    }


    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player" && !hideScript.isHidden)
        {
            walking.Interactable = false;
            walking.InteractionCode = null;
            hideScript = null;
            if (walking != null && !walking.Interactable && walking.InteractionCode == null && !isDoor)
            {
                walking = null;
                Debug.Log("Left Door");
            }
        }

        if (player.tag == "NPC" && isSwitch && !isHideOut)
            isOn = false;
    }
}
