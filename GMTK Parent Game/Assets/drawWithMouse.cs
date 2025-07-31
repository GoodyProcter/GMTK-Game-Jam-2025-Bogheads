using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawWithMouse : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField] private float minDistance = 0.1f;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;
    }

    private void Update()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition.z = 0f;

        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                if (previousPosition == transform.position)
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
            CircleCollider2D circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
            circleCollider2D.isTrigger = true;
            line.positionCount = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("MouseInteractable"))
        {
            Debug.Log("Collided with: " + collision.gameObject.name);
            CircleCollider2D colliderToDestroy = GetComponent<CircleCollider2D>();
            Destroy(colliderToDestroy);
        }
        else
        {
            CircleCollider2D colliderToDestroy = GetComponent<CircleCollider2D>();
            Destroy(colliderToDestroy);
        }
        
    }
}
