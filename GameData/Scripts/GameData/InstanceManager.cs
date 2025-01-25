using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstanceMan : MonoBehaviour
{
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StorePosition()
    {
        string SceneName = SceneManager.GetActiveScene().name;

        InstanceManager.Instance.AddPlayerPosition(SceneName, Player.transform.position);
    }
}
