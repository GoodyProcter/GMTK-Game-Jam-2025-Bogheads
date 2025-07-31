using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawManagerScript : MonoBehaviour
{
    private Camera camera;


    private LineRenderer line;
    private Vector3 previousPosition;
   [SerializeField] private float minDistance = 0.1f;
    public GameObject LineStartPos;
    public GameObject LineEndPos;
    public ringColliderScript ringColliderScript;

    public float colliderDespawnTime; 

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;
            LineStartPos.transform.position = currentPosition;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                if( previousPosition == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                }
                previousPosition = currentPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;

            LineEndPos.transform.position = currentPosition;

            line.positionCount = 0;
            colliderDespawnTime = 3f;

            ringColliderScript.growRing();
        }

        if(colliderDespawnTime > 0)
        {
            colliderDespawnTime -= Time.deltaTime;
        }

        if(colliderDespawnTime <= 0)
        {
            ringColliderScript.shrinkRing();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Interactable")
        {
            Debug.Log("Circled Interactable");
        }
    }
}
