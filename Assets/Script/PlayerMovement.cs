using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour{

    Camera cam;
    public LayerMask groundMask;
    public PlayerAnimation playerAnimation;
    
    void Start(){
        cam = Camera.main;
    }
    
    void Update()
    {
        // Using new Input System
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Mouse clicked!"); // Test if this appears first
            
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            
            // Try raycast without layer mask first
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit object: " + hit.collider.name);

            }
            else
            {
                Debug.Log("No object hit by raycast");
            }
        }
    }
}

    

