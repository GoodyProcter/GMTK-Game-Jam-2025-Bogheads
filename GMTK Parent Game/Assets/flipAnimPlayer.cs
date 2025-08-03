using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipAnimPlayer : MonoBehaviour

{
    public SpriteRenderer sprite;
    new Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!Input.GetKeyDown(KeyCode.W)) && (!Input.GetKeyDown(KeyCode.S)))
        {
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)))
                {
                Vector2 currentPosition = transform.position;
                float deltax = currentPosition.x - lastPosition.x;

                if (deltax < 0.0f)
                {
                    sprite.flipX = true;
                }
                else sprite.flipX = false;

                lastPosition = currentPosition;
                }
        }

           
    }
}
