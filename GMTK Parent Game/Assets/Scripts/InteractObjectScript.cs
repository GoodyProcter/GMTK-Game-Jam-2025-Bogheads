using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectScript : MonoBehaviour
{
    public cursorScript cursorScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        cursorScript.OnMouseEnter();
    }

    private void OnMouseExit()
    {
        cursorScript.OnMouseExit();
    }
}
