using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallObjectScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public GameObject player;
    public PlayerMovement playerMovement;
    public GameObject particles;

    [SerializeField] Sprite[] randomBreakables;
    private Sprite newSprite;



    // Start is called before the first frame update
    void Start()
    {
        newSprite = randomBreakables[Random.Range(0, randomBreakables.Length)];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
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
            //if (collision.gameObject.tag == "Small Breakable")
            //{
            //    return;
            //}
            //else
            //{
                Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            //}
            
        }
        
    }

    public void AddForce()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myRigidBody.AddForce((transform.up * playerMovement.playerMoveY) / 120);
            myRigidBody.AddForce((transform.right * playerMovement.playerMoveX) / 120);
        }
        else
        {
            myRigidBody.AddForce((transform.up * playerMovement.playerMoveY) / 100);
            myRigidBody.AddForce((transform.right * playerMovement.playerMoveX) / 100);
        }

        

        
    }
}
