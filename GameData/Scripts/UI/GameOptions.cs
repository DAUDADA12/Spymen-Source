using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public GameObject ResetButton;

    public void Restart()
    {
        if(InstanceManager.Instance.Chances > 0)
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    void FixedUpdate() 
    {
        if(InstanceManager.Instance.Chances < 1)
            ResetButton.SetActive(false);
    }

    public void SwitchScene(string NextLevel)
    {
        SceneManager.LoadSceneAsync(NextLevel);
    }
}
