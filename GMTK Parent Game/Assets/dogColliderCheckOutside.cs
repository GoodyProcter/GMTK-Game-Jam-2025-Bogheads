using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogColliderCheckOutside : MonoBehaviour
{
    public GameObject dog;
    //public bool hasDogCollided = false;
    public string flagName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == dog.name)
        {
            Debug.Log("Dog Outside Perma");
            GameFlags.Instance.SetFlag(flagName, true);
            Debug.Log("DOG HAS SET FLAG" + flagName);
        }
    }
}
