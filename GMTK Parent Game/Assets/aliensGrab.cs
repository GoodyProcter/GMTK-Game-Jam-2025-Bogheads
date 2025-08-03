using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aliensGrab : MonoBehaviour
{
    public GameObject dog;

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
        if (collision.gameObject.name == dog.name)
        {
            dog.transform.position = gameObject.transform.position;
            gameObject.transform.rotation *= Quaternion.Euler(1, 0, 0);
        }
    }
}
