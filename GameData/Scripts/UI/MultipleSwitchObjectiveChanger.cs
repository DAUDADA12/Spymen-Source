using UnityEngine;
using UnityEngine.UI;

public class MultipleSwitchObjectiveChanger : MonoBehaviour
{
    public Text ObjectiveText;
    public int UnlockedDoors;
    [TextArea(2,10)]
    public string SentenceToWrite;
    public Toggle toggle;
    private int LockCount;
    public GetInteraction[] Lock;

    void Start()
    {
        ObjectiveText = toggle.GetComponentInChildren<Text>();
    }
    void FixedUpdate()
    {
        UnlockedDoors = 0;
        LockCount = 0;

        UnlockedDoors = CountLock();

        ObjectiveText.text = SentenceToWrite + "(" + (Lock.Length - UnlockedDoors).ToString() + "/" + Lock.Length + ")";

        if(UnlockedDoors == Lock.Length)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    int CountLock()
    {
        foreach (var Lock in Lock)
        {
            if (Lock.isOn)
            {
                LockCount++;
            }
        }

        return LockCount;
    }

}
