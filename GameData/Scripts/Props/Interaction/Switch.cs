using UnityEngine;

public class Switch : MonoBehaviour
{
    [HideInInspector] public Walking walking;
    [HideInInspector] public bool isOn;
    [HideInInspector] public bool isDoor;
    [HideInInspector] public bool isOneofMoreKey;
    private Collider2D Trigger;

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
            if (walking != null)
            {
                walking.Interactable = true;
                walking.InteractionCode = GetComponent<GetInteraction>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            walking.Interactable = false;
            walking.InteractionCode = null;
            if (walking != null && !walking.Interactable && walking.InteractionCode == null && !isDoor)
            {
                walking = null;
            }
        }
    }
}
