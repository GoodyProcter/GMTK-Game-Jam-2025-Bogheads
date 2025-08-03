using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static BasicAI;

public class BasicAI : MonoBehaviour
{
    [System.Serializable]
    public class RoutineStep
    {
        public Transform destination; // transform to walk to
        public float waitTime = 1f; // how long to wait once they get there
        public bool waitForTrigger = false; // if true, wait forever until told to continue, not sure it works
        public string skipIfTrue; // optional - flag name, if true then skip that step 
        public string skipIfFalse;
        public string stepName; // nickname to jump to this step
    }

    public List<RoutineStep> routineSteps; // the list of steps to follow (set in inspector)

    private int currentStep = 0; // index of current step 
    private bool isWaiting = false; // if true, then currently waiting before it moves again (not walking)
    private bool routinePaused = false; // if true, then routine is paused - when doing something else like following player

    private NavMeshAgent agent; // link to the navmesh agent

    public Transform followTarget; // the player
    public bool isFollowingPlayer = false; // if true then follow player each frame 

    private int prevWaitTimer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // setup the pathfinding
        agent.updateRotation = false; // prevent rotation updates
        agent.updateUpAxis = false; 

        StartStep(); // begin the routine
    }

    private void Update()
    {
        // if following the player, continously update destination to their position
        if (isFollowingPlayer && followTarget != null)
        {
            agent.SetDestination(followTarget.position); 
            return; // skip routine while following
        }

        // if paused or waiting, do nothing this frame
        if (routinePaused || isWaiting) return; 

        // check if reached destination by calculating distance difference
        if (!agent.pathPending && agent.remainingDistance <= 0.1f && agent.velocity.magnitude <= 0.01f)
        {
            // get current step from list
            RoutineStep step = routineSteps[currentStep];

            // if the step needs a manual trigger to continue like waiting for player interaction of something
            if (step.waitForTrigger)
            {
                isWaiting = true; // pause until TriggerNextStep() is called
            }
            else
            {
                // otherwise wait for given duration and then move on
                StartCoroutine(WaitThenNext(step.waitTime));
            }
        }
    }

    // used for delays before moving to next step
    IEnumerator WaitThenNext(float waitTime)
    {
        isWaiting = true;
        int startedStep = currentStep;
        Debug.Log($"{name} started step {startedStep}");
        yield return new WaitForSeconds(waitTime);

        if (currentStep != startedStep || currentStep != prevWaitTimer)
        {
            yield break;
        }

        isWaiting = false;
        NextStep();

    }

    // if waiting for trigger, call externally to continue
    public void TriggerNextStep()
    {
        if (!isWaiting) return;

        // stop any running WaitThenNexts
        StopAllCoroutines();

        isWaiting = false;
        NextStep();
    }

    // move to next step in the list
    private void NextStep()
    {
        currentStep++;

        // if reached end of list, stay on last step
        if (currentStep >= routineSteps.Count)
        {
            currentStep = routineSteps.Count - 1;
            return;
        }

        StartStep();
    }

    // start / resume step by moving to destination
    private void StartStep()
    {
        isWaiting = false; 

        // don't start if currently paused like following player
        if (routinePaused) return;

        // get the current step
        RoutineStep step = routineSteps[currentStep];

        // check if step should be skipped based on game flag like "FoodReady" 
        if (!string.IsNullOrEmpty(step.skipIfTrue) && GameFlags.Instance.GetFlag(step.skipIfTrue))
        {
            currentStep++;
            StartStep(); // call until valid step found
            return;
        }

        // check if step should be not skipped based on game flag like "FoodReady" 
        if (!string.IsNullOrEmpty(step.skipIfFalse) && !GameFlags.Instance.GetFlag(step.skipIfFalse))
        {
            Debug.Log("should skip because false");
            
            currentStep++;
            StartStep(); // call until valid step found
            return;
        }

        prevWaitTimer = currentStep;

        Debug.Log($"{name} started step {currentStep}");

        Debug.Log($"{name} dest = {step.destination.name}");

        // otherwise start walking to destination
        agent.SetDestination(step.destination.position);
    }

    // called when AI starts to follow player
    public void StartFollowing(Transform player)
    {
        isFollowingPlayer = true;
        followTarget = player;
        routinePaused = true;
    }

    // called to stop following and jump to specific routine step
    public void StopFollowing(string stepName)
    {
        // stop following player
        isFollowingPlayer = false;
        followTarget = null;

        // resume normal list of steps
        routinePaused = false;

        // look for step with that nickname like "Eat" or "Sleep"
        int index = routineSteps.FindIndex(s => s.stepName == stepName);

        if (index >= 0)
        {
            currentStep = index; // set that step as current step
            StartStep(); // begin that step
        }
        else
        {
            Debug.LogWarning($"step '{stepName}' not found on {name}");
        }
    }
}