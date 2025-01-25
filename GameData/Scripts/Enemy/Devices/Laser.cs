using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject Player;
    private Walking Player_Code;
    private AudioSource LaserSound;

    void Start()
    {
        LaserSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LaserSound.Play();

        if (other.tag == "NPC")
            Destroy(other.gameObject);

        if (other.tag == "Player")
        {
            Player = other.gameObject;

            if (Player != null)
            {
                Player_Code = Player.GetComponent<Walking>();
                Player_Code.isDead = true;
            }
        }
    }
}
