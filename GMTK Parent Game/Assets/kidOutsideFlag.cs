using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kidOutsideFlag : MonoBehaviour
{
    public GameObject kid;
    public bool hasKidCollided = false;
    public string flagName = "";

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
        if (collision.gameObject.name == kid.name)
        {
            GameFlags.Instance.SetFlag(flagName, true);
        }
    }
}
