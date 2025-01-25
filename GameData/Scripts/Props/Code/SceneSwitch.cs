using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public string SceneName;
    [HideInInspector] public GetInteraction Code;
    private bool Use;
    private Image Code_BlendImage;
    private Scene activeScene;
    private Transform Player;
    private AudioSource DoorSound;

    void Start()
    {
        Code = GetComponent<GetInteraction>();
        Code.isDoor = true;
        activeScene = SceneManager.GetActiveScene();
        DoorSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Use && Code_BlendImage.color.a == 1f)
        {
            if (Player != null)
            {
                SceneManager.LoadScene(SceneName);
                StorePosition();
                return;
            }
        }
    }

    void FixedUpdate()
    {
        if (Code.isOn)
        {
            DoorSound.mute = false;
            if(DoorSound.isPlaying)
            {
                Code.walking.isUsed = true;
                Code_BlendImage = Code.walking.BlendImage;
                Code_BlendImage = Code.walking.BlendImage;
                if (Code.walking.isUsed)
                {
                    Use = true;
                    Player = Code.walking.transform;
                }
            }
        }
    }

    public void StorePosition()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        InstanceManager.Instance.AddPlayerPosition(currentSceneName, Player.position);
        return;
    }
}
