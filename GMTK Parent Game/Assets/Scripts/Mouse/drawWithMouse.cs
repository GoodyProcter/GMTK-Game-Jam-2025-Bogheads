using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawWithMouse : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 previousPosition;
    [SerializeField] private float minDistance = 0.1f;
    private bool colliderActive = false;
    private float countDownDestroyCollider;
    public Interactable circledInteractable;

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

        if (colliderActive == true)
        {
            if(countDownDestroyCollider > 0)
            {
                countDownDestroyCollider -= Time.deltaTime;
            }            

            if(countDownDestroyCollider <= 0)
            {
                CircleCollider2D colliderToDestroy = gameObject.GetComponent<CircleCollider2D>();
                Destroy(colliderToDestroy);
                colliderActive = false;
            }
        }

            if (Input.GetMouseButton(0))
        {
            if(colliderActive == true)
            {
                CircleCollider2D colliderToDestroy = gameObject.GetComponent<CircleCollider2D>();
                Destroy(colliderToDestroy);
                colliderActive = false;
            }
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
            if (line.positionCount > 10)
            {
                CircleCollider2D circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
                colliderActive = true;
                countDownDestroyCollider = 0.1f;
                circleCollider2D.isTrigger = true;
                line.positionCount = 0;
                

            }
            else line.positionCount = 0;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("MouseInteractable"))
        {
            Debug.Log("Collided with: " + collision.gameObject.name);
            CircleCollider2D colliderToDestroy = GetComponent<CircleCollider2D>();
            circledInteractable = collision.gameObject.GetComponent<Interactable>();
            circledInteractable.Interact();
            
            Destroy(colliderToDestroy);
            colliderActive = false;
        }
        else
        {
            CircleCollider2D colliderToDestroy = GetComponent<CircleCollider2D>();
            Destroy(colliderToDestroy);
            colliderActive = false;
        }
        
    }
}
