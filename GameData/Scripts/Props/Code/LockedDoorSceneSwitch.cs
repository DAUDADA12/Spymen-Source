using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoorSceneSwitch : MonoBehaviour
{
    public string SceneName;
    public string KeyNeeded;
    [HideInInspector] public GetInteraction Code;
    private bool Use;
    private Image Code_BlendImage;
    private Scene activeScene;
    private AudioSource audiosource;
    private Transform Player;
    public bool Locked;

    void Start()
    {
        Code = GetComponent<GetInteraction>();
        Code.isDoor = true;
        activeScene = SceneManager.GetActiveScene();
        audiosource = GetComponent<AudioSource>();

        Locked = true;
    }

    void FixedUpdate()
    {
        if (Code.isOn)
        {
            Open();
        }

        if (Use)
        {
            audiosource.mute = false;
            if(Code_BlendImage.color.a == 1f)
                SceneManager.LoadScene(SceneName);
        }
    }

    void Open()
    {
        Locked = !InstanceManager.Instance.GetKey(KeyNeeded);
        if (!Locked)
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
        else
            Debug.Log("Door is Locked!!");
    }

    public void StorePosition()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        InstanceManager.Instance.AddPlayerPosition(currentSceneName, Player.position);
    }
}
