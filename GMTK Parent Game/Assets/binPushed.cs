using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binPushed : MonoBehaviour
{
    public GameObject gene;
    public bool hasGeneCollided = false;
    public string flagName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(hasGeneCollided == false)
        {
            if (collision.name == gene.name)
            {
                binFall();
                hasGeneCollided = true;
            }
        }

    }

    public void binFall()
    {
        gameObject.transform.rotation *= Quaternion.Euler(0, 0, 180);

        gameObject.transform.position = new Vector3 (-0, -3, -1);

        GameFlags.Instance.SetFlag(flagName, true);

    }
}
