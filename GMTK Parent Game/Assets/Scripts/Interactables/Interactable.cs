using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactable : MonoBehaviour
{
    private bool hasInteracted = false; // stop repeat use 
    public bool batteriesHidden;
    public GameObject dogMiniGame;
    public miniGameChecker miniGameChecker;

    [Header("Task Info")]
    public string taskName = ""; 
    public string setFlagOnInteract; // flag to sent after interaction
    public int scoreValue; // score added after interaction

    [Header("Interaction Conditions")]
    public List<string> requireTrueFlags; // all must be true
    public List<string> requireFalseFlags; // all must be false

    [Header("References")]
    public BasicAI NPC; // reference to NPC basicAI script
    public ScoreController scoreController;

    // what this interaction does, set in inspector in the interactable tasks
    public enum ActionType
    {
        None, // does nothing
        FollowPlayer, // makes them follow player
        GoToStep // makes go to named routine step
    }

    [Header("Action")]
    public ActionType Action = ActionType.None; // what to do on interaction
    public string StepName; // used only for GoToStep - the name of routine step to send them to

    private void Update()
    {
       
    }

    public void Interact()
    {
        Debug.Log("Mouse Interacted with " + gameObject.name);

        if (hasInteracted) return;

        // check flag conditions first
        foreach (var flag in requireTrueFlags)
        {
            if (!GameFlags.Instance.GetFlag(flag)) return;
        }
        foreach (var flag in requireFalseFlags)
        {
            if (GameFlags.Instance.GetFlag(flag)) return;
        }

        hasInteracted = true;

        // set flag like "FoodReady" that other scripts can use
        if (!string.IsNullOrEmpty(setFlagOnInteract)) GameFlags.Instance.SetFlag(setFlagOnInteract, true);

        if (NPC != null)
        {
            switch (Action)
            {
                case ActionType.FollowPlayer:
                    var player = GameObject.FindWithTag("Player")?.transform;
                    if (player) NPC.StartFollowing(player); // tell to follow
                    break;

                case ActionType.GoToStep:
                    if (!string.IsNullOrEmpty(StepName))
                        NPC.StopFollowing(StepName); // send to specific step
                    break;
            }
        }

        // add score to player
        if (scoreController != null)
        {
            scoreController.score += scoreValue;
            scoreController.scoreText.SetText("Score: " + scoreController.score.ToString());
        }

        Debug.Log($"Task completed: {taskName}");

        if(gameObject.name == "REMOTE")
        {
            batteriesHidden = true;
        }

        if(gameObject.name == "DOGDOOR")
        {
            dogMiniGame.SetActive(true);
            miniGameChecker.miniGameActive = true;
        }
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
