using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public float Distance = -10f;
    [HideInInspector] public bool Stop;
    private Walking PlayerCode;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            PlayerCode = Player.GetComponent<Walking>();
            if (PlayerCode != null)
                PlayerCode.PlayerCam = gameObject.GetComponent<CameraMovement>();
        }
    }

    void Update()
    {
        if (Player != null && !Player.IsDestroyed())
        {
            float PlayerPosition = Player.transform.position.x;

            Vector3 vector = new Vector3(PlayerPosition, transform.position.y, Distance);

            transform.position = vector;

            if (Player.IsDestroyed())
            {
                return;
            }
        }
    }
}
