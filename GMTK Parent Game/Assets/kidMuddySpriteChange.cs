using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kidMuddySpriteChange : MonoBehaviour
{
    [SerializeField] Sprite[] kidSprites;
    private Sprite newSprite;
    public bool kidMuddy;

    // Start is called before the first frame update
    void Start()
    {
        newSprite = kidSprites[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kidMuddy == true)
        {
            newSprite = kidSprites[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        else newSprite = kidSprites[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    


}
