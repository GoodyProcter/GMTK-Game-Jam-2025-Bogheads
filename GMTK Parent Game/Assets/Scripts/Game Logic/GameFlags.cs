using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlags : MonoBehaviour
{
    public static GameFlags Instance; // global access

    private Dictionary<string, bool> flags = new Dictionary<string, bool>(); // stores the flag name and true/false state

    private void Awake()
    {
        // only one instance can exist, kill duplicate
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // call to enable/disable flag
    public void SetFlag(string key, bool value)
    {
        flags[key] = value;
    }

    // check if flag is on
    public bool GetFlag(string key)
    {
        return flags.ContainsKey(key) && flags[key];
    }

    // used for like restart or new game
    public void ClearFlags()
    {
        flags.Clear();
    }
}
