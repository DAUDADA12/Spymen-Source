using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHighlighter : MonoBehaviour
{
    private GetInteraction interaction;
    public Toggle ObjectiveCheckbox;

    void Start()
    {
        interaction = GetComponent<GetInteraction>();
    }

    void FixedUpdate()
    {
        if(interaction.isOn)
            ObjectiveCheckbox.isOn = true;
        else
            ObjectiveCheckbox.isOn = false;
    }
}
