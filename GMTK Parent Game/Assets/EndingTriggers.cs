using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTriggers : MonoBehaviour
{
    bool kidAwake;
    bool kidStillEating;
    bool kidStillatTV;
    bool kidMuddy;
    bool kidHungry;

    // check flags each frame and uses first matching ending, not great sorry
    void Update()
    {
        // ending 1 - kid never wakes up
        if (kidAwake == false)
        {
            Ending(1); return;
        }

        // ending 2 - bins blcoked door
        if (GameFlags.Instance.GetFlag("doorsBlocked"))
        {
            Ending(2); return;
        }

        // ending 3 - missed bus cuz of slow eati g
        if (kidStillEating == true)
        {
            Ending(3); return;
        }

        // ending 4 - kid watched TV too long
        if (kidStillatTV == true)
        {
            Ending(4); return;
        }

        // ending 5 - dog kidnapped
        if (GameFlags.Instance.GetFlag("dogGrabbed"))
        {
            Ending(5); return;
        }

        // ending 6 - kid made it but hungry/muddy
        if (kidMuddy == true);
        {
            Ending(6); return; //muddy
        }

        // ending 6 - kid made it but hungry/muddy
        if (kidHungry == true);
        {
            Ending(6); return; //muddy
        }

        // final ending
        if (GameFlags.Instance.GetFlag("kidOutside");
        {
            Ending(7); return;
        }
    }

    // replace with scene loading, UI, dialogue, whatever
    private void Ending(int number)
    {
        Debug.Log("ENDING" + number);
        enabled = false;
    }
}
