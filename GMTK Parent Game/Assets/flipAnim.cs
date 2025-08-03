using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipAnim : MonoBehaviour

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
        Vector2 currentPosition = transform.position;
        float deltax = currentPosition.x - lastPosition.x;

        if (deltax > 0.0f)
        {
            sprite.flipX = true;
        }
        else sprite.flipX = false;

        lastPosition = currentPosition;

    }
}
