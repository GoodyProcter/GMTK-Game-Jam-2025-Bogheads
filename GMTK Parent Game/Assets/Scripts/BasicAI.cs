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
        public string stepName;
    }

    public List<RoutineStep> routineSteps;
    private int currentStep = 0;
    private bool isWaiting = false;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        GoToNextStep();
    }

    private void Update()
    {
        if (agent.pathPending || isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= 0.1f)
        {
            if (routineSteps[currentStep].waitForTrigger == false)
            {
                StartCoroutine(WaitThenNext(routineSteps[currentStep].waitTime));
            }
            else
            {
                isWaiting = true;
            }
        }
    }

    IEnumerator WaitThenNext(float waitTime)
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentStep = (currentStep + 1) % routineSteps.Count;
        GoToNextStep();
    }

    public void TriggerNextStep()
    {
        if (!isWaiting) return;
        isWaiting = false;
        currentStep = (currentStep + 1) % routineSteps.Count;
        GoToNextStep();
    }

    private void GoToNextStep()
    {
        RoutineStep step = routineSteps[currentStep];
        agent.SetDestination(step.destination.position);
    }
}
