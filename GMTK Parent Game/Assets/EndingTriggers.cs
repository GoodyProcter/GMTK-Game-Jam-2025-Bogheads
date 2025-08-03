using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTriggers : MonoBehaviour
{
    bool kidAwake;
    public bool kidLeftTable;
    public bool kidStillatTV;
    public bool kidMuddy;
    public bool kidHungry;
    public ScoreController scoreController;
    public int endingNum;

    // check flags each frame and uses first matching ending, not great sorry
    void Update()
    {
        // ending 1 - kid never wakes up
        if (!GameFlags.Instance.GetFlag("kidAwake"))
        {
            endingNum = 1;
        }
        else if (GameFlags.Instance.GetFlag("doorsBlocked"))
        {
            endingNum = 2;
        }
        else if (kidLeftTable == false)
        {
            endingNum = 3;
        }
        else if (kidStillatTV == true)
        {
            endingNum = 4;
        }
        else if (GameFlags.Instance.GetFlag("dogGrabbed"))
        {
            endingNum = 5;
        }
        else if (GameFlags.Instance.GetFlag("kidOutside"))
        {
            if (kidMuddy == true)
            {
                endingNum = 6;
            }
            else endingNum = 7;
        }

        if(scoreController.timer <= 0)
        {
            Ending();
        }
    }

    // replace with scene loading, UI, dialogue, whatever
    void Ending()
    {
        SceneManager.LoadScene(endingNum + 1);
    }
}

