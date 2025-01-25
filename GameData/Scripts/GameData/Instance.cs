using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager Instance { get; private set; }

    public Dictionary<string, Vector2> ScenePlayerPosition = new Dictionary<string, Vector2>();
    public Dictionary<string, bool> Keys = new Dictionary<string, bool>();
    public int HP = 100;
    [HideInInspector] public int Stored_HP;
    [HideInInspector] public int Stored_Chances;
    public int Chances = 3;
    [HideInInspector]public int MaxHealth;

    private void Awake()
    {
        Stored_Chances = Chances;
        Stored_HP = HP;
        MaxHealth = HP;

        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(Instance);
        }
    }

    private void Update() {
        if(Chances < 0)
            Chances = 0;
    }

    public int GetHealthInfo()
    {
        return HP;
    }

    public void Damaged(int Damage)
    {
        HP -= Damage;
    }

    public void AddKey(string KeyName)
    {
        Keys[KeyName] = true;
        Debug.Log("Player got " + KeyName);
    }

    public bool GetKey(string KeyName)
    {
        if (Keys.ContainsKey(KeyName))
            return Keys[KeyName];

        else
            return false;
    }

    public void AddPlayerPosition(string SceneName, Vector2 PlayerPosition)
    {
        ScenePlayerPosition[SceneName] = PlayerPosition;
        Debug.Log("Position :" + PlayerPosition.ToString() + " is saved!");
        return;
    }

    public Vector2 GetPlayerPosition(string SceneName)
    {
        if (ScenePlayerPosition.ContainsKey(SceneName))
            return ScenePlayerPosition[SceneName];

        else
            return Vector2.zero;
    }
    public void ClearPosition()
    {
        ScenePlayerPosition.Clear();
    }

    public void ClearKey()
    {
        Keys.Clear();
    }

    public void RemoveKeyList(List<string> keysToRemove)
    {        // Remove the keys from the dictionary
        foreach (string key in keysToRemove)
        {
            Keys.Remove(key);
        }
    }
}