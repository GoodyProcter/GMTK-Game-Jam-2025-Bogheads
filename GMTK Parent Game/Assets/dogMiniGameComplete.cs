using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogMiniGameComplete : MonoBehaviour
{
    public string flagName = "";
    public string flagName2 = "";
    public miniGameChecker miniGameChecker;
    public GameObject dog;
    public GameObject dogTeleport;
    public GameObject dogMiniGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject key = gameObject.transform.GetChild(0).gameObject;
        if (key.name == ("Key"))
        {
            GameFlags.Instance.SetFlag(flagName, true);
            GameFlags.Instance.SetFlag(flagName2, true);
            miniGameChecker.miniGameActive = false;
            dog.transform.position = dogTeleport.transform.position;
            dogMiniGame.SetActive(false);
        }
    }   
    
}
