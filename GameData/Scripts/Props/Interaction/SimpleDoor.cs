using UnityEngine;

public class SimpleDoor : MonoBehaviour
{
    public Animator AnimatorController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            AnimatorController.SetBool("Open", true);

        if(other.tag == "NPC")
            AnimatorController.SetBool("Open", true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
            AnimatorController.SetBool("Open", false);

        if(other.tag == "NPC")
            AnimatorController.SetBool("Open", false);
    }

    void OnTriggerStay2D(Collider2D player)
    {
        if(player.tag == "Player")
            AnimatorController.SetBool("Open", true);

        if(player.tag == "NPC")
            AnimatorController.SetBool("Open", true);
    }
}
