using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tvOn : MonoBehaviour
{
    public Interactable interactable;
    [SerializeField] Sprite[] tvSprites;
    [SerializeField] Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        newSprite = tvSprites[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Kid")
        {
            kidTurnOnTV();
        }
    }

    void kidTurnOnTV()
    {
        if (interactable.batteriesHidden == false)
        {
            newSprite = tvSprites[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
