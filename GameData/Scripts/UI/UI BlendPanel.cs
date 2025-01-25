using UnityEngine;

public class UIBlendPanel : MonoBehaviour
{
    public bool Ready;
    public Walking Player;
    public Animator Panel;

    void FixedUpdate() 
    {
        if(Player != null)
        {
            if(Ready)
            {
                Player.enabled = false;
                Panel.SetBool("isUsed", true);
            }
            else
            {
                Player.enabled = true;
                Panel.SetBool("isUsed", false);
            }
        }
    }
}
