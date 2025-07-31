using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringColliderScript : MonoBehaviour
{
    public drawManagerScript drawManagerScript;
    public GameObject LineEndPos;
    public GameObject LineStartPos;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D ringCollider = GetComponent<CircleCollider2D>();
        ringCollider.radius = 0;
        ringCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shrinkRing()
    {
        CircleCollider2D ringCollider = GetComponent<CircleCollider2D>();
        ringCollider.radius = 0;

        
    }

    public void growRing()
    {
        CircleCollider2D ringCollider = GetComponent<CircleCollider2D>();
        float radius = Vector2.Distance(drawManagerScript.LineStartPos.transform.position, drawManagerScript.LineEndPos.transform.position);
        ringCollider.radius = radius;
        gameObject.transform.position = 0.5f * (LineStartPos.transform.position + LineEndPos.transform.position);

        Debug.Log(radius);
    }
}
