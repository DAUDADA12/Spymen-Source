using Unity.VisualScripting;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform Target;
    public TargetSetter TargetCode;
    [SerializeField] private GameObject Indicator;
    [SerializeField]private Transform Player;

    void Start()
    {
        if(Player == null)
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Target = TargetCode.Target.transform;
    }
    void FixedUpdate() {
        if(TargetCode.Target != null)
        {
            Target = TargetCode.Target.transform;
            transform.position = Player.position;

            Vector3 direction = Target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            if(TargetCode.Target.isVisible)
                Indicator.SetActive(false);
            else
                Indicator.SetActive(true);
        }

        if(TargetCode.Target.gameObject.IsDestroyed())
            Destroy(gameObject);
    }
}
