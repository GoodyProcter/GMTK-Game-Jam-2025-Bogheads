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
        public Transform destination;
        public float waitTime = 1f;
        public bool waitForTrigger = false;
        public string requiredFlag; // wait until flag is true
        public string skipIfTrue; // skip if flag already true
        public string stepName;
    }

    public List<RoutineStep> routineSteps;
    private int currentStep = 0;
    private bool isWaiting = false;
    private bool routinePaused = false;

    private NavMeshAgent agent;

    public Transform followTarget;
    public bool isFollowingPlayer = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StartStep();
    }

    private void Update()
    {
        if (isFollowingPlayer && followTarget != null)
        {
            agent.SetDestination(followTarget.position);
            return;
        }

        if (routinePaused || isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= 0.1f && agent.velocity.magnitude <= 0.01f)
        {
            RoutineStep step = routineSteps[currentStep];

            if (step.waitForTrigger)
            {
                isWaiting = true;
            }
            else if (!string.IsNullOrEmpty(step.requiredFlag) && !GameFlags.Instance.GetFlag(step.requiredFlag))
            {
                isWaiting = true;
            }
            else
            {
                StartCoroutine(WaitThenNext(step.waitTime));
            }
        }
    }

    IEnumerator WaitThenNext(float waitTime)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        GoToNextStep();
    }

    public void TriggerNextStep()
    {
        if (!isWaiting) return;
        isWaiting = false;
        GoToNextStep();
    }

    private void GoToNextStep()
    {
        currentStep++;

        if (currentStep >= routineSteps.Count)
        {
            currentStep = routineSteps.Count - 1; // stay at final step
            return;
        }

        StartStep();
    }

    private void StartStep()
    {
        isWaiting = false;
        if (routinePaused) return;

        RoutineStep step = routineSteps[currentStep];

        // Skip if skipIfTrue is already true
        if (!string.IsNullOrEmpty(step.skipIfTrue) && GameFlags.Instance.GetFlag(step.skipIfTrue))
        {
            currentStep++;
            StartStep();
            return;
        }

        // Wait if required flag not yet true
        if (!string.IsNullOrEmpty(step.requiredFlag) && !GameFlags.Instance.GetFlag(step.requiredFlag))
        {
            isWaiting = true;
            return;
        }

        agent.SetDestination(step.destination.position);
    }

    public void StartFollowingPlayer(Transform player)
    {
        isFollowingPlayer = true;
        followTarget = player;
        routinePaused = true; 
    }

    public void StopFollowingAndGoToStep(string stepName)
    {
        isFollowingPlayer = false;
        followTarget = null;
        routinePaused = false;

        int index = routineSteps.FindIndex(s => s.stepName == stepName);
        if (index >= 0)
        {
            currentStep = index;
            StartStep();
        }
        else
        {
            Debug.LogWarning($"Step '{stepName}' not found on {name}");
        }
    }
}