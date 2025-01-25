using System.Collections;
using UnityEngine;

public class GuardWalk : MonoBehaviour
{
    [HideInInspector] public Animator AnimationController;
    [HideInInspector] public float Direction;
    public Transform PointOne;
    public Transform PointTwo;
    public float Speed = 1f;
    public float WaitTime = 3f;
    public float AttackCooldown = 1f;
    private Rigidbody2D RB;
    [HideInInspector]public float Speed_Stored;
    private AudioSource FootstepSound;
    private float RunSpeed_Stored;
    public float RunSpeed = 2f;
    public bool SawPlayer;
    [HideInInspector] public Transform Player;
    public GameObject ExclaimationText;
    private bool isCorutineActive = false;
    public bool CCTVAlarm = false;
    public bool StartAttack;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AnimationController = GetComponent<Animator>();
        FootstepSound = GetComponent<AudioSource>();

        Direction = 1f;
        Speed_Stored = Speed;
        RunSpeed_Stored = RunSpeed;
    }

    void Update()
    {
        float velocityMagnitude = Speed * Direction;

        Vector2 velocity = new Vector2(velocityMagnitude, 0f);

        RB.linearVelocity = velocity;

        CheckDirection();
        Run();
    }

    void FixedUpdate()
    {
        if(StartAttack)
        {
            GetComponent<GuardAttack>().enabled = true;
        }
    }

    void Run()
    {
        if (SawPlayer)
        {
            ExclaimationText.SetActive(true);
            Speed = RunSpeed;
            StopAllCoroutines();
            isCorutineActive = false;
            if (transform.position.x < Player.position.x)
                Direction = 1;
            else
                Direction = -1;
        }
        else if(CCTVAlarm)
        {
            ExclaimationText.SetActive(true);
            Speed = RunSpeed;
            StopAllCoroutines();
            isCorutineActive = false;
            if (transform.position.x < Player.position.x)
                Direction = 1;
            else
                Direction = -1;
        }
        else
        {
            ExclaimationText.SetActive(false);
            RangeDetect();
        }
    }

    void CheckDirection()
    {
        if (Direction < 0f)
            transform.rotation = Quaternion.Euler(0, 180f, 0f);
        if (Direction > 0f)
            transform.rotation = Quaternion.Euler(0, 0f, 0f);

        if (RB.linearVelocity.x != 0f)
        {
            AnimationController.SetBool("isWalk", true);
            FootstepSound.mute = false;
        }
        else
        {
            AnimationController.SetBool("isWalk", false);
            FootstepSound.mute = true;
        }

        if(Speed == RunSpeed_Stored)
        {
            FootstepSound.pitch = 1.34f;
        }
        else
        {
            FootstepSound.pitch = 1f;
        }
    }

    private void OnDisable() {
        FootstepSound.mute = true;
    }

    void RangeDetect()
    {
        if (transform.position.x <= PointTwo.position.x && transform.position.x >= PointOne.position.x)
            isCorutineActive = false;

        if (!SawPlayer && !isCorutineActive)
        {
            if (transform.position.x < PointOne.position.x)
            {
                StartCoroutine(DirectionChange());
            }
            if (transform.position.x > PointTwo.position.x)
            {
                StartCoroutine(DirectionChange());
            }
        }
    }

    private IEnumerator DirectionChange()
    {
        Speed = 0f;
        isCorutineActive = true;

        yield return new WaitForSeconds(WaitTime);

        if (transform.position.x <= PointOne.position.x)
            Direction = 1f;
        if (transform.position.x >= PointTwo.position.x)
            Direction = -1f;
        Speed = Speed_Stored;
    }
}
