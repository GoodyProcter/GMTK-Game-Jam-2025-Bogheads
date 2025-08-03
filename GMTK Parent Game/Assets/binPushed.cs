using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binPushed : MonoBehaviour
{
    public GameObject gene;
    public bool hasGeneCollided = false;
    public string flagName = "";
    public Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
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

        rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;



    }
}
