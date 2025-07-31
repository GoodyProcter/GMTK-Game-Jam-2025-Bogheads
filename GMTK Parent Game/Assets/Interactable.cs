using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool playerInRange = false;
    private bool hasInteracted = false;
    private PlayerMovement playerMovement;
    private SpriteRenderer sr;

    [Header("Task Info")]
    public string taskName = "temp";
    public float interactionDelay = 0f;
    public string setFlagOnInteract;
    public int scoreValue;

    [Header("References")]
    public BasicAI dogAI;
    public ScoreController scoreController;

    public enum ActionType
    {
        None,
        FollowPlayer,
        GoToStep
    }

    [Header("Action")]
    public ActionType dogAction = ActionType.None;
    public string dogStepName;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null) Debug.LogWarning("no SpriteRenderer found on that object");
    }

    private void Update()
    {
        if (playerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;
            StartCoroutine(DelayedInteract());
        }
    }

    private IEnumerator DelayedInteract()
    {
        if (playerMovement != null) playerMovement.SetInteracting(true);

        // Turn object green while interacting
        if (sr != null) sr.color = Color.green;

        yield return new WaitForSeconds(interactionDelay);

        Interact();

        if (playerMovement != null) playerMovement.SetInteracting(false);

        // After interaction set to white
        if (sr != null) sr.color = Color.white;
    }

    private void Interact()
    {
        Debug.Log("task completed: " + taskName);

        if (!string.IsNullOrEmpty(setFlagOnInteract))
        {
            GameFlags.Instance.SetFlag(setFlagOnInteract, true);
        }

        if (dogAI != null)
        {
            switch (dogAction)
            {
                case ActionType.FollowPlayer:
                    Transform player = GameObject.FindWithTag("Player")?.transform;
                    if (player != null)
                        dogAI.StartFollowingPlayer(player);
                    break;

                case ActionType.GoToStep:
                    if (!string.IsNullOrEmpty(dogStepName))
                        dogAI.StopFollowingAndGoToStep(dogStepName);
                    break;
            }
        }

        if (scoreController != null)
        {
            scoreController.currentinteractingObject = gameObject;
            scoreController.taskScoreIncrease();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (playerMovement == null)
                playerMovement = other.GetComponent<PlayerMovement>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Just in case interaction got interrupted
            if (playerMovement == null)
                playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
                playerMovement.SetInteracting(false);
        }
    }
}
