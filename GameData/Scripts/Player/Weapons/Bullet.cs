using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 10;
    public float DespawnTime = 10f;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "NPC")
        {
            other.gameObject.GetComponent<GuardHealth>().Health -= Damage;
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(DespawnTime);

        Destroy(gameObject);
    }
}
