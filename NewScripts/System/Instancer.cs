using UnityEngine;

public class Instancer : MonoBehaviour
{
    public static Instancer Instance {get; private set;}

    public bool PlayerAvailable;
    public Player PlayerCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;

            DontDestroyOnLoad(Instance);
        }
    }

    void CheckPlayer(Player player)
    {
        if(!PlayerAvailable)
        {
            PlayerAvailable = true;
            PlayerCode = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
