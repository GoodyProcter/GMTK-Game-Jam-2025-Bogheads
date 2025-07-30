using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cursorScript : MonoBehaviour
{

    private Camera mainCamera;

    public Texture2D defaultMouseTexture;
    public Texture2D hoverMouseTexture;
    public Texture2D grabMouseTexture;

    public float mouseResetTimer = 0.15f;
    public bool mouseResetTrigger = false;

    public int mouseState;


    private void Awake()
    {
        mainCamera = Camera.main;
        Cursor.SetCursor(defaultMouseTexture, new Vector2(0, 0), CursorMode.ForceSoftware);
        mouseState = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    private void Update()
    {
        if(mouseResetTrigger == true)
        {
            mouseResetTimer -= Time.deltaTime;
        }

        if(mouseResetTrigger == true && mouseResetTimer <= 0)
        {
            Cursor.SetCursor(defaultMouseTexture, new Vector2(0, 0), CursorMode.ForceSoftware);
            mouseState = 1;
            mouseResetTrigger = false;
        }
    }

     public void OnMouseEnter()
    {
        if(mouseState == 1)
        {
            Cursor.SetCursor(hoverMouseTexture, new Vector2(0, 0), CursorMode.ForceSoftware);
            mouseState = 2;
        }
        
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultMouseTexture, new Vector2(0, 0), CursorMode.ForceSoftware);
        mouseState = 1;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(pos:(Vector3)Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);
        Cursor.SetCursor(grabMouseTexture, new Vector2(0, 0), CursorMode.ForceSoftware);
        mouseState = 3;
        mouseResetTimer = 0.15f;
        mouseResetTrigger = true;

    }

}

    
