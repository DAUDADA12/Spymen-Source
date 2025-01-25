using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MultipleSwitchDoor : MonoBehaviour
{
    [HideInInspector] public bool Locked;
    public string SceneName;
    public GetInteraction[] Lock;
    public int LockCount;
    public int UnlockedDoors;
    [HideInInspector] public GetInteraction Code;
    private Image Code_BlendImage;
    private Transform Player;
    private bool Use;

    void Start()
    {
        LockCount = 0;
        Code = GetComponent<GetInteraction>();
        Code.isDoor = true;

        for (int i = 0; i < Lock.Length; i++)
            Lock[i].isOneofMoreKey = true;
    }

    void FixedUpdate()
    {
        UnlockedDoors = 0;
        LockCount = 0;


        if (Code.isOn && !Locked)
        {
            Code.walking.isUsed = true;
            Code_BlendImage = Code.walking.BlendImage;
            Code_BlendImage = Code.walking.BlendImage;
            if (Code.walking.isUsed)
            {
                Use = true;
                Player = Code.walking.transform;

                if (Player != null)
                {
                    StorePosition();
                }
            }
        }

        if (Use && Code_BlendImage.color.a == 1f && !Locked)
        {
            SceneManager.LoadScene(SceneName);
        }

        UnlockedDoors = CountLock();

        if (UnlockedDoors == Lock.Length)
        {
            Locked = false;
        }
        else
        {
            Locked = true;
        }
    }

    public void StorePosition()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        InstanceManager.Instance.AddPlayerPosition(currentSceneName, Player.position);

        return;
    }

    public int CountLock()
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

    private void OnTriggerExit2D(Collider2D other)
    {
        Code.isOn = false;
    }
}
