using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttack : MonoBehaviour
{
    public float AttackCooldown;
    public int Damage = 10;

    private GuardWalk guard;
    private Animator animator;
    private Transform Player;
    private GuardAttack guardAttack;

    // Start is called before the first frame update
    void Awake()
    {
        guard = GetComponent<GuardWalk>();
        animator = GetComponent<Animator>();
        guardAttack = GetComponent<GuardAttack>();
    }

    void OnEnable()
    {
        StartCoroutine(Attack());
    }

    void Update()
    {
        Player = guard.Player;
    }

    private IEnumerator Attack()
    {
        guard.Speed = 0f;

        guard.enabled = false;
        animator.SetBool("isWalk", false);

        yield return new WaitForSeconds(AttackCooldown);

        animator.SetBool("Punch", true);

        if(Player != null && guard.StartAttack)
        {
            guard.StartAttack = false;
            InstanceManager.Instance.Damaged(Damage);
        }

        yield return new WaitForSeconds(0.1f);

        guard.enabled = true;
        guardAttack.enabled = false;
        guard.Speed = guard.Speed_Stored;
        guard.StartAttack = false;

        animator.SetBool("Punch", false);
        StopAllCoroutines();
    }
}
