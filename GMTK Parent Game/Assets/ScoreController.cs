using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score;
    public float timer;
    public Text scoreText;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 180;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText = timer.ToString();
    }
}
