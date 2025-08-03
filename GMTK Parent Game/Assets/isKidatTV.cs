using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isKidatTV : MonoBehaviour
{
    public GameObject kid;
    public EndingTriggers endingTriggers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == kid.name)
        {
            endingTriggers.kidStillatTV = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == kid.name)
        {
            endingTriggers.kidStillatTV = false;
        }
    }
}
