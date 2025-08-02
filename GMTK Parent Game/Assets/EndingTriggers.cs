using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTriggers : MonoBehaviour
{
    // check flags each frame and uses first matching ending, not great sorry
    void Update()
    {
        // ending 1 - kid never wakes up
        if (GameFlags.Instance.GetFlag("KidOverslept"))
        {
            Ending(1); return;
        }

        // ending 2 - bins blcoked door
        if (GameFlags.Instance.GetFlag("BinsBlocked") && GameFlags.Instance.GetFlag("LeavingAttempted"))
        {
            Ending(2); return;
        }

        // ending 3 - missed bus cuz of slow eati g
        if (GameFlags.Instance.GetFlag("TooSlow"))
        {
            Ending(3); return;
        }

        // ending 4 - kid watched TV too long
        if (GameFlags.Instance.GetFlag("KidTV"))
        {
            Ending(4); return;
        }

        // ending 5 - dog kidnapped
        if (GameFlags.Instance.GetFlag("AliensCame") && GameFlags.Instance.GetFlag("DogOutside"))
        {
            Ending(5); return;
        }

        // ending 6 - kid made it but hungry/muddy
        if (GameFlags.Instance.GetFlag("KidMuddy") || GameFlags.Instance.GetFlag("KidHungry"))
        {
            Ending(6); return;
        }

        // final ending
        if (GameFlags.Instance.GetFlag("OnBus") && !GameFlags.Instance.GetFlag("KidMuddy") && !GameFlags.Instance.GetFlag("KidHungry"))
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
