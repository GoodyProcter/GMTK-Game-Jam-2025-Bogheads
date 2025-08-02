using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWhenFlag : MonoBehaviour
{
    // put on any object when you use waitForTrigger = true
    // this checks boolean flag, once true it calls npc.TriggerNextStep() to continue the next step
    // i really hope this works fine :sob:
    public BasicAI npc;
    public string flagName = ""; // name of flag that resumes the routine like KidWoke

    private void Update()
    {
        if (GameFlags.Instance.GetFlag(flagName))
        {
            npc.TriggerNextStep();
            enabled = false; // only do once then disable
        }
    }
}
