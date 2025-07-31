using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectBumpScoreLowerer : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public ScoreController scoreController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("any object collided with player");
        if (collision.gameObject.name == "Player")
        {
            scoreController.scoreDecrease();
            if(scoreController.scoreDecreaseDelay <= 0)
            {
                scoreController.scoreDecreaseDelay = 0.25f;
            }

        }
    }
}

