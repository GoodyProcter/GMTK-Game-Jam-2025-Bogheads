using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalFlag : MonoBehaviour
{
    // put on trigger zone with IsTrigger = true
    // when an npc enters zone it sets flag - was hoping to use for dog jumping up
    public string flagName = "";

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // only for NPCs
        if (collider.GetComponent<BasicAI>() == null) return;
        GameFlags.Instance.SetFlag(flagName, true);
    }
}
