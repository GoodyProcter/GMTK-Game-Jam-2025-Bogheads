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
        if (Input.GetKey(KeyCode.S) == true)
        {
            Debug.Log("down");

            animator.SetBool("Down", true);
            
            animator.SetBool("Up", false);
        } 
        else animator.SetBool("Down", false);

        if(Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.S) == false)
        {
            Debug.Log("up");

            animator.SetBool("Up", true);

            animator.SetBool("Down", false);
        }
        else animator.SetBool("Up", false);

    }
        
    
}
