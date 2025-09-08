using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    public LayerMask groundMask;
    public PlayerAnimation playerAnimation;

    void Start()
    {
        cam = Camera.main;
        
        // Check if PlayerAnimation is assigned
        if (playerAnimation == null)
        {
            playerAnimation = GetComponent<PlayerAnimation>();
            if (playerAnimation == null)
            {
                Debug.LogError("PlayerAnimation component not found! Please assign it in the Inspector or add it to this GameObject.");
            }
        }
    }
    
    void Update()
    {
        // Using new Input System
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            
            // Try raycast without layer mask first
            if (Physics.Raycast(ray, out hit))
            {
               if (playerAnimation != null)
               {
                   playerAnimation.MovetoPoint(hit.point);
               }
               else
               {
                   Debug.LogError("PlayerAnimation is null! Make sure it's assigned in the Inspector.");
               }
            }
        }
    }
}
