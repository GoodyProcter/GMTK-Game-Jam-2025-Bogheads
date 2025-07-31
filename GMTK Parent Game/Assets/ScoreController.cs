using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score;
    public float timer;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    public GameObject currentinteractingObject;
    public Interactable currentObjectScript;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 180;
        scoreText.SetText("Score: " + score.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        string timerTextString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.SetText("Timer: " + timerTextString);

        if (timer <= 0)
        {
            timer = 0;
        }

    }

    public void taskScoreIncrease()
    {
        currentObjectScript = currentinteractingObject.GetComponent<Interactable>();

        score += currentObjectScript.scoreValue;

        scoreText.SetText("Score: " + score.ToString());
    }

    void taskScoreDecrease()
    {

    }


}
