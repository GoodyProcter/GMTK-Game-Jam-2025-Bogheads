using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimatorController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("down");

            animator.SetBool("Down", true);
            
            animator.SetBool("Up", false);
        } 
        else animator.SetBool("Down", false);

        if((Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.S) == false) || (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == false) || (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) == false))
        {
            Debug.Log("up");

            animator.SetBool("Up", true);

            animator.SetBool("Down", false);
        }
        else animator.SetBool("Up", false);

    }
        
    
}
