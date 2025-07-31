using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallObjectScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public GameObject player;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector2 direction = gameObject.transform.position - transform.position;
            AddForce();

        }
        else
        {
            if(collision.gameObject.tag == "Small Breakable")
            {
                return;
            } else Destroy(gameObject);
        }
        
    }

    public void AddForce()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myRigidBody.AddForce((transform.up * playerMovement.playerMoveY) / 90);
            myRigidBody.AddForce((transform.right * playerMovement.playerMoveX) / 90);
        }
        else
        {
            myRigidBody.AddForce((transform.up * playerMovement.playerMoveY) / 75);
            myRigidBody.AddForce((transform.right * playerMovement.playerMoveX) / 75);
        }

        

        
    }
}
