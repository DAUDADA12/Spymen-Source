using UnityEngine;

public class Initializer : MonoBehaviour
{
    public GameObject Players;
    public static Player PlayerCode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCode = Players.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
