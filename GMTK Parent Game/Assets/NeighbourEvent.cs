using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourEvent : MonoBehaviour
{
    // script to check after a delay to check dog flag and choose if neighbour was woken up or late - so bins blocked
    public float delay = 10f;
    private bool triggered = false;

    private void Update()
    {
        if (triggered || Time.timeSinceLevelLoad < delay) return;
        triggered = true;

        bool dogOutside = GameFlags.Instance.GetFlag("DogOutside");
        bool dogDistracted = GameFlags.Instance.GetFlag("DogDistracted");

        if (dogOutside && !dogDistracted)
        {
            GameFlags.Instance.SetFlag("NeighbourWoken", true);
            GameFlags.Instance.SetFlag("BinsBlocked", false);
        }
        else
        {
            GameFlags.Instance.SetFlag("NeighbourWoken", false);
            GameFlags.Instance.SetFlag("BinsBlocked", true);
        }
    }
}
