using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D PlayerRB;
    private Animator PlayerAnimator;

    
    public float WalkSpeed = 3;
    public float JumpForce = 2;
    public bool WalkLeft = false;
    public bool WalkRight;
    public bool JumpUp;
    [HideInInspector]public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate() 
    {
        Debug.Log($"Velocity: {PlayerRB.linearVelocity}");

        if(JumpUp)
            Jump();

        if(WalkLeft)
            Walk_Left();
        else if(WalkRight)
            Walk_Right();
        else
            Walk(0);
    }

    void Jump()
    {
        if(isGrounded)
        {
            PlayerRB.linearVelocity = new Vector2(PlayerRB.linearVelocity.x, JumpForce);
            isGrounded = false;
        }
    }

    public void ToggleJump(bool TheBool)
    {
        JumpUp = TheBool;
    }

    public void ToggleLeft(bool TheBool)
    {
        WalkLeft = TheBool;
    }
    public void ToggleRight(bool TheBool)
    {
        WalkRight = TheBool;
    }

    void Walk_Left()
    {
        Walk(-1);
    }

    void Walk_Right()
    {
        Walk(1);
    }

    void OnCollisionEnter2D(Collision2D Surface) 
    {
        if(Surface.gameObject.tag == "Ground")
        {
            isGrounded = true;
            PlayerAnimator.SetBool("isGrounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D Surface)
    {
        if(Surface.gameObject.tag == "Ground")
        {
            isGrounded = false;
            PlayerAnimator.SetBool("isGrounded", false);
        }
    }

    
    void Walk(float Effector)
    {
        float Speed = WalkSpeed * Effector;

        if (Speed != 0f)
            PlayerAnimator.SetBool("Walking", true);
        else
        {
            PlayerAnimator.SetBool("Walking", false);
        }
        Vector2 Velocity = new Vector2(Speed, PlayerRB.linearVelocity.y);

        PlayerRB.linearVelocity = Velocity;

        if (Speed < 0f)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0f);
        }
        if (Speed > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0f, 0f);
        }
    }
}
