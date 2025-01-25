using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public float Range = 100f;
    public float AttackRange = 1f;
    private GuardWalk Code;
    RaycastHit2D hit;
    RaycastHit2D AttackRay;
    [HideInInspector] public bool CCTVtrigger;

    void Start()
    {
        Code = GetComponent<GuardWalk>();
    }

    void FixedUpdate()
    {
        int layerMask = LayerMask.GetMask("Player", "Door");
        if (transform.rotation.y != 0)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, -Range, layerMask, 0);
            Debug.DrawRay(transform.position, -Vector2.right * Range, Color.red);


            AttackRay = Physics2D.Raycast(transform.position, Vector2.right, -AttackRange, layerMask, 0);
            Debug.DrawRay(transform.position, -Vector2.right * AttackRange + Vector2.up * 0.1f, Color.blue);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, Range, layerMask, 0);
            Debug.DrawRay(transform.position, Vector2.right * Range, Color.red);


            AttackRay = Physics2D.Raycast(transform.position, Vector2.right, AttackRange, layerMask, 0);
            Debug.DrawRay(transform.position, Vector2.right * AttackRange + Vector2.up * 0.1f, Color.blue);
        }

        if (AttackRay.collider != null && AttackRay.collider.gameObject.layer != 6)
        {
            Code.StartAttack = true;
        }
        else
            Code.StartAttack = false;


        if (hit.collider != null && hit.collider.gameObject.layer != 6)
        {
            if (hit.collider.gameObject.tag == "Player" && !Code.CCTVAlarm)
            {
                Code.SawPlayer = true;
                Code.Player = hit.collider.transform;
            }
        }
        else
        {
            Code.SawPlayer = false;
        }
    }
}
