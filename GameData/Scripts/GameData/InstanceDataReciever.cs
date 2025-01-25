using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstanceDataReciever : MonoBehaviour
{
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        string currentSceneName = SceneManager.GetActiveScene().name;

        Vector2 lastPosition = InstanceManager.Instance.GetPlayerPosition(currentSceneName);

        if (lastPosition == Vector2.zero)
        {
            Player.transform.position = Player.transform.position;
        }

        else
        {
            Player.transform.position = lastPosition;
        }
    }
}
