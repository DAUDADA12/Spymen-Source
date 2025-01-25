using UnityEngine;

public class AudioListnerManager : MonoBehaviour
{
    public UIBlendPanel BlendPanelCode;
    private AudioListener audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioListener>();
        audioSource.enabled = false;
    }

    void FixedUpdate()
    {
        if(!BlendPanelCode.Ready)
            audioSource.enabled = true;
        else
            audioSource.enabled = false;
    }
}
