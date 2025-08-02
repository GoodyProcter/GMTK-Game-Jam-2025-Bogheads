using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kidDogCollide : MonoBehaviour
{
    public Interactable interactableKid;
    public Interactable interactableDog;
    public GameObject kid;
    public GameObject dog;
    [SerializeField] bool kidEntered = false;
    [SerializeField] bool dogEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kidEntered == true && dogEntered == true)
        {
            interactableKid.Interact();
            interactableDog.Interact();
        }
    }

   

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("something has collided with jumpspot");

        if (other.gameObject.name == ("Kid"))
        {
            kidEntered = true;
            Debug.Log(kidEntered);
        }

        if (other.gameObject.name == ("Dog"))
        {
            dogEntered = true;
            Debug.Log(dogEntered);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == ("Kid"))
        {
            kidEntered = false;
        }

        if (other.gameObject.name == ("Dog"))
        {
            dogEntered = false;
        }
    }


}
