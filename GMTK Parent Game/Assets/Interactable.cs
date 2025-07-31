using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool playerInRange = false;

    public string taskName = "temp";

    public ScoreController scoreController;

    public int scoreValue;

    private void Update()
    {
        //if (playerInRange && Input.GetKeyDown(KeyCode.E))
        //{
        //    Interact();
        //}
    }

    public void Interact()
    {
        Debug.Log("task completed: " + taskName);
        scoreController.currentinteractingObject = gameObject;
        scoreController.taskScoreIncrease();
        Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerInRange = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerInRange = false;
    //    }
    //}
}
